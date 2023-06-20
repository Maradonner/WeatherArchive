using Microsoft.AspNetCore.Mvc;
using WeatherArchive.BL.Services.Interfaces;
using WeatherArchive.ViewModels;

namespace WeatherArchive.Controllers;

public class UploadController : Controller
{
    private readonly IExcelService _excelService;
    private readonly IWeatherRecordService _weatherRecordService;
    private readonly ILogger<UploadController> _logger;

    public UploadController(IWeatherRecordService weatherRecordService, IExcelService excelService, ILogger<UploadController> logger)
    {
        _weatherRecordService = weatherRecordService;
        _excelService = excelService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult<UploadViewModel>> Index(CancellationToken ct)
    {
        var files = Request.Form.Files;

        if (files.Count == 0)
        {
            ModelState.AddModelError("", "Please select at least one file.");
            return View();
        }

        foreach (var file in files)
        {
            if (file.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                ModelState.AddModelError("", "File format is not valid. Only .xlsx formats are allowed.");
                return View();
            }
        }

        foreach (var file in files)
        {
            if (file.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                return BadRequest("Invalid file type. Please upload an Excel file.");

            var weatherRecords = _excelService.ReadWeatherData(file);
            try
            {
                var result = await _weatherRecordService.UploadWeatherRecordsAsync(weatherRecords, ct);
                if (!result)
                {
                    _logger.LogError("File just not saved into database with that properties {file}", file);
                    return BadRequest("File just not saved");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Invalid data came to the service {file}", file);
                return BadRequest("Invalid Data into Excel file provided");
            }
        }

        return Redirect("/");
    }
}