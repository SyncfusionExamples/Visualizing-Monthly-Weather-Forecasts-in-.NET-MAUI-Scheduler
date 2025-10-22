using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ForecastMAUI
{
    public class WeatherForecastViewModel : INotifyPropertyChanged, IWeatherProvider
    {
        private DateTime _selectedDate = DateTime.Today;
        private string _currentLocation = "Washington, DC";
        private TemperatureUnit _selectedTemperatureUnit = TemperatureUnit.Fahrenheit;

        public WeatherForecastViewModel()
        {
            _selectedTemperatureUnit = TemperatureUnit.Fahrenheit;

            // Initialize with sample data
            GenerateWeatherData();
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
                GenerateWeatherData(); // Refresh data when date changes
            }
        }

        public string CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;
            }
        }

        public ObservableCollection<WeatherForecast> WeatherForecasts { get; set; } = new();    

        public Dictionary<DateTime, WeatherForecast> WeatherLookup { get; set; } = new();

        public ObservableCollection<string> TemperatureUnits { get; set; } = new() { "Fahrenheit", "Celsius" };

        public TemperatureUnit SelectedTemperatureUnit
        {
            get => _selectedTemperatureUnit;
            set
            {
                _selectedTemperatureUnit = value;
            }
        }

        public string SelectedTemperatureUnitString
        {
            get => _selectedTemperatureUnit.ToString();
            set
            {
                if (Enum.TryParse<TemperatureUnit>(value, out var unit))
                {
                    SelectedTemperatureUnit = unit;
                }
            }
        }
        private void GenerateWeatherData()
        {
            // Add null checks before clearing collections
            WeatherForecasts?.Clear();
            WeatherLookup?.Clear();

            var firstDayOfMonth = new DateTime(SelectedDate.Year, SelectedDate.Month, 1);
            //// Iniitially load for 3 months. 
            var startDate = firstDayOfMonth.AddMonths(-1).AddDays(-15);
            var endDate = firstDayOfMonth.AddMonths(2).AddDays(15);

            var conditions = new[] { "Sunny", "Partly Cloudy", "Cloudy", "Rainy", "Thunderstorm", "Snow" };
            var icons = new[] { "☀️", "⛅", "☁️", "🌧️", "⛈️", "❄️" };

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                var random = new Random(date.DayOfYear + date.Year);
                var conditionIndex = random.Next(0, conditions.Length);

                // Always generate base temperatures in Fahrenheit for consistency
                // The converter will handle the display conversion
                var baseTempHigh = random.Next(70, 95);
                var baseTempLow = random.Next(45, 75);


                // Convert to Celsius if needed
                var tempHigh = _selectedTemperatureUnit == TemperatureUnit.Celsius
                    ? (int)((baseTempHigh - 32) * 5.0 / 9.0)
                    : baseTempHigh;

                var tempLow = _selectedTemperatureUnit == TemperatureUnit.Celsius
                    ? (int)((baseTempLow - 32) * 5.0 / 9.0)
                    : baseTempLow;


                var weatherForecast = new WeatherForecast
                {
                    Date = date,
                    TemperatureHigh = tempHigh,  
                    TemperatureLow = tempLow,   
                    Icon = icons[conditionIndex],
                    Location = CurrentLocation,
                    TemperatureUnit = _selectedTemperatureUnit 
                };

                WeatherForecasts?.Add(weatherForecast);
                if (WeatherLookup != null)
                {
                    WeatherLookup[date.Date] = weatherForecast;
                }
            }
        }

        public WeatherForecast? GetWeatherForDate(DateTime date)
        {
            return WeatherLookup.TryGetValue(date.Date, out var weather) ? weather : null;
        }

        public string GetTemperatureUnitSymbol()
        {
            return SelectedTemperatureUnit == TemperatureUnit.Fahrenheit ? "°F" : "°C";
        }

        public string TemperatureUnitSymbol => GetTemperatureUnitSymbol();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
