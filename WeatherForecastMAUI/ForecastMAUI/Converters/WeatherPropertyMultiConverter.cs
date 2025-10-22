using System.Globalization;

namespace ForecastMAUI
{
    public class WeatherPropertyMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2)
                return string.Empty;

            if (values[0] is not DateTime dateTime)
                return string.Empty;


            if (values[1] is not IWeatherProvider provider)
                return string.Empty;

       
            var data = provider.GetWeatherForDate(dateTime);
            if (data == null)
                return string.Empty;

            var prop = parameter as string ?? string.Empty;
            var symbol = provider.TemperatureUnitSymbol;

            return prop switch
            {
                "HighTemp" => $"{data.TemperatureHigh}{symbol}",
                "LowTemp" => $"{data.TemperatureLow}{symbol}",
                "WeatherIcon" => data.Icon ?? string.Empty,
                _ => string.Empty
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotSupportedException();

       
    }
}
