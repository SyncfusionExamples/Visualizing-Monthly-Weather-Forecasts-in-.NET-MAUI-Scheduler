
namespace ForecastMAUI
{
    /// <summary>
    /// Represents a weather forecast for a specific date and location.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets the date of the forecast.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the highest temperature expected on the forecast date.
        /// </summary>
        public int TemperatureHigh { get; set; }

        /// <summary>
        /// Gets or sets the lowest temperature expected on the forecast date.
        /// </summary>
        public int TemperatureLow { get; set; }

        /// <summary>
        /// Gets or sets the weather icon representing the forecast (e.g., sunny, cloudy).
        /// </summary>
        public string? Icon { get; set; }

        /// <summary>
        /// Gets or sets the location for which the forecast is provided.
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        ///Gets or sets the unit of temperature used in the forecast.
        /// </summary>
        public TemperatureUnit TemperatureUnit { get; set; } = TemperatureUnit.Fahrenheit;

        /// <summary>
        /// Gets the symbol representing the temperature unit (°F or °C).
        /// </summary>
        public string TemperatureUnitSymbol => TemperatureUnit == TemperatureUnit.Fahrenheit ? "°F" : "°C";
    }

    /// <summary>
    /// Specifies the unit of temperature used in a weather forecast.
    /// </summary>
    public enum TemperatureUnit
    {
        /// <summary>
        /// Temperature is measured in degrees Fahrenheit.
        /// </summary>
        Fahrenheit,

        /// <summary>
        /// Temperature is measured in degrees Celsius.
        /// </summary>
        Celsius
    }
}