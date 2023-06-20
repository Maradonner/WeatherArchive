using AutoMapper;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WeatherArchive.BL.Helpers;
using WeatherArchive.BL.Services.Interfaces;
using WeatherArchive.DAL.Entities;
using WeatherArchive.Models;

namespace WeatherArchive.BL.Services;

public class ExcelService : IExcelService
{
    private readonly IMapper _mapper;
    private readonly ILogger<ExcelService> _logger;

    public ExcelService(IMapper mapper, ILogger<ExcelService> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    public List<WeatherRecord> ReadWeatherData(IFormFile excelData)
    {
        var weatherRecordsDto = new List<WeatherRecordDto>();

        using var stream = excelData.OpenReadStream();
        IWorkbook workbook = new XSSFWorkbook(stream);

        for (var sheetIndex = 0; sheetIndex < workbook.NumberOfSheets; sheetIndex++)
        {
            var sheet = workbook.GetSheetAt(sheetIndex);
            var rows = sheet.GetRowEnumerator();

            for (var i = 0; i < 4; i++)
                rows.MoveNext();

            while (rows.MoveNext())
            {
                var row = (IRow)rows.Current;
                var weatherRecordDto = CreateWeatherRecordDtoFromRow(row);

                var veire = _mapper.Map<WeatherRecord>(weatherRecordDto);


                if (weatherRecordDto != null)
                    weatherRecordsDto.Add(weatherRecordDto);
            }
        }

        var weatherRecords = _mapper.Map<List<WeatherRecord>>(weatherRecordsDto);

        return weatherRecords;
    }

    private WeatherRecordDto? CreateWeatherRecordDtoFromRow(IRow row)
    {
        return new WeatherRecordDto
        {
            DateTime = row.GetCell(0)?.ParseCellToDateTime(),
            MoscowTime = row.GetCell(1)?.ParseCellToTimeSpan(),
            Temperature = row.GetCell(2)?.ParseCellToDouble(),
            RelativeHumidity = row.GetCell(3)?.ParseCellToDouble(),
            Td = row.GetCell(4)?.ParseCellToDouble(),
            AtmosphericPressure = row.GetCell(5)?.ParseCellToInt(),
            WindDirection = row.GetCell(6)?.ParseCellToString(),
            WindVelocity = row.GetCell(7)?.ParseCellToDouble(),
            Cloudiness = row.GetCell(8)?.ParseCellToInt(),
            CloudinessLowerBoundary = row.GetCell(9)?.ParseCellToInt(),
            HorizontalVisibility = row.GetCell(10)?.ParseCellToInt(),
            WeatherPhenomena = row.GetCell(11)?.ParseCellToString()
        };
    }
}