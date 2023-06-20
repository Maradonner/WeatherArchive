using Microsoft.EntityFrameworkCore;
using WeatherArchive.DAL.Entities;

namespace WeatherArchive.DAL.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<WeatherRecord> WeatherRecords { get; set; }
}