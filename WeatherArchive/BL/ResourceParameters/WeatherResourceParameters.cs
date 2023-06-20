using System.ComponentModel.DataAnnotations;

namespace WeatherArchive.BL.ResourceParameters;

public class WeatherResourceParameters
{
    private const int _maxPageSize = 50;
    private int _pageSize = 25;

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > _maxPageSize ? _maxPageSize : value;
    }

    public int Month { get; set; }
    public int Year { get; set; }
}