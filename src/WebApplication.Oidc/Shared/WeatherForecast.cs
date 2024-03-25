using System;

namespace WebApplication.Oidc.Shared;

public sealed class WeatherForecast
{
    public DateTime Date { get; init; }

    public int TemperatureC { get; init; }

    public string Summary { get; init; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}