using WeatherArchive.BL.Helpers;
using WeatherArchive.BL.ResourceParameters;

namespace WeatherArchive.ViewModels;

public class DisplayViewModel<T>
{
    public WeatherResourceParameters WeatherResourceParameters { get; set; }
    public PagedList<T> PagedList { get; set; }
}