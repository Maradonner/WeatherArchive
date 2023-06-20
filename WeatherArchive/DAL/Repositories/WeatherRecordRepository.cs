using WeatherArchive.DAL.Data;
using WeatherArchive.DAL.Entities;
using WeatherArchive.DAL.Repositories.Interfaces;

namespace WeatherArchive.DAL.Repositories;

public class WeatherRecordRepository : IWeatherRecordRepository
{
    private readonly AppDbContext _context;

    public WeatherRecordRepository(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<WeatherRecord> GetWeatherRecords()
    {
        return _context.WeatherRecords.AsQueryable();
    }

    public async Task AddWeatherRecordsAsync(List<WeatherRecord> weatherRecords)
    {
        await _context.AddRangeAsync(weatherRecords);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}