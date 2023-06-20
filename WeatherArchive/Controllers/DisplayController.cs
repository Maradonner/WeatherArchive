using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WeatherArchive.BL.ResourceParameters;
using WeatherArchive.BL.Services.Interfaces;
using WeatherArchive.DAL.Entities;
using WeatherArchive.ViewModels;

namespace WeatherArchive.Controllers;

public class DisplayController : Controller
{
    private readonly IWeatherRecordService _weatherRecordService;

    public DisplayController(IWeatherRecordService weatherRecordService)
    {
        _weatherRecordService = weatherRecordService;
    }

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] WeatherResourceParameters parameters, CancellationToken ct)
    {
        var collection = await _weatherRecordService.GetWeatherRecordsAsync(parameters, ct);

        return View(new DisplayViewModel<WeatherRecord>
        {
            PagedList = collection,
            WeatherResourceParameters = parameters
        });
    }
}