using WeatherArchive.BL.Helpers;
using WeatherArchive.BL.ResourceParameters;
using WeatherArchive.BL.Services.Interfaces;
using WeatherArchive.DAL.Entities;
using WeatherArchive.DAL.Repositories.Interfaces;

namespace WeatherArchive.BL.Services;

public class WeatherRecordService : IWeatherRecordService
{
    private readonly IWeatherRecordRepository _repository;
    private readonly ILogger<WeatherRecordService> _logger;

    public WeatherRecordService(IWeatherRecordRepository repository, ILogger<WeatherRecordService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<PagedList<WeatherRecord>> GetWeatherRecordsAsync(WeatherResourceParameters parameters,
        CancellationToken ct)
    {
        var query = _repository.GetWeatherRecords();

        if (parameters.Year != 0)
            query = query.Where(x => x.DateTime.Year == parameters.Year);
        if (parameters.Month != 0)
            query = query.Where(x => x.DateTime.Month == parameters.Month);

        query = query.OrderBy(x => x.DateTime).ThenBy(x => x.MoscowTime);

        return await PagedList<WeatherRecord>.CreateAsync(query, parameters.PageNumber, parameters.PageSize, ct);
    }

    public async Task<bool> UploadWeatherRecordsAsync(List<WeatherRecord> weatherRecords, CancellationToken ct)
    {
        try
        {
            await _repository.AddWeatherRecordsAsync(weatherRecords);
            var result = await _repository.SaveChangesAsync();

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while uploading the weather records.");
            throw;
        }
    }
}