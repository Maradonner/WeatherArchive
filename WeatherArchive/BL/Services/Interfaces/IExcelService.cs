using WeatherArchive.DAL.Entities;
using WeatherArchive.Models;

namespace WeatherArchive.BL.Services.Interfaces;

public interface IExcelService
{
    List<WeatherRecord> ReadWeatherData(IFormFile excelData);
}