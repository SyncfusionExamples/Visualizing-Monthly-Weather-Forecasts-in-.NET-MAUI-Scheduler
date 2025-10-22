namespace ForecastMAUI
{
    public interface IWeatherProvider
    {
        // Data retrieval
        WeatherForecast? GetWeatherForDate(DateTime date);

        // Unit info
        TemperatureUnit SelectedTemperatureUnit { get; }
        string TemperatureUnitSymbol { get; }
    }
}
