using WeatherArchive.BL.Helpers;
using WeatherArchive.BL.ResourceParameters;
using WeatherArchive.DAL.Entities;

namespace WeatherArchive.BL.Services.Interfaces;

public interface IWeatherRecordService
{
    Task<PagedList<WeatherRecord>> GetWeatherRecordsAsync(WeatherResourceParameters parameters, CancellationToken ct);
    Task<bool> UploadWeatherRecordsAsync(List<WeatherRecord> weatherRecords, CancellationToken ct);
}