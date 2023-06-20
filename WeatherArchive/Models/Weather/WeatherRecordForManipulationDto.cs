﻿namespace WeatherArchive.Models.Weather;

public abstract class WeatherRecordForManipulationDto
{
    public DateTime? DateTime { get; set; }
    public TimeSpan? MoscowTime { get; set; }
    public double? Temperature { get; set; }
    public double? RelativeHumidity { get; set; }
    public double? Td { get; set; }
    public int? AtmosphericPressure { get; set; }
    public string? WindDirection { get; set; } = string.Empty;
    public double? WindVelocity { get; set; }
    public int? CloudinessLowerBoundary { get; set; }
    public int? HorizontalVisibility { get; set; }
    public string? WeatherPhenomena { get; set; } = string.Empty;
}