using System.Globalization;

namespace ForecastMAUI
{
    public class TodayColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not DateTime date)
                return Colors.Black;

            return date.Date == DateTime.Today ? Colors.Blue : Colors.Black;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
