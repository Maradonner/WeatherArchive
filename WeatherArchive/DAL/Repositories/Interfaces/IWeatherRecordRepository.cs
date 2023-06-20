using WeatherArchive.DAL.Entities;

namespace WeatherArchive.DAL.Repositories.Interfaces;

public interface IWeatherRecordRepository
{
    IQueryable<WeatherRecord> GetWeatherRecords();
    Task AddWeatherRecordsAsync(List<WeatherRecord> weatherRecords);
    Task<bool> SaveChangesAsync();
}