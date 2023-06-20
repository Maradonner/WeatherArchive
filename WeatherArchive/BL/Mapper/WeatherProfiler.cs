using AutoMapper;
using WeatherArchive.DAL.Entities;
using WeatherArchive.Models;

namespace WeatherArchive.BL.Mapper;

public class WeatherProfiler : Profile
{
    public WeatherProfiler()
    {
        CreateMap<WeatherRecord, WeatherRecordDto>().ReverseMap();
    }
}