# Visualizing a Monthly Weather Forecast Calendar in .NET MAUI Scheduler

## Overview
This project demonstrates how to build a monthly weather forecast calendar using the Syncfusion .NET MAUI Scheduler control. It showcases custom cell templates, weather icons, temperature ranges, and unit switching between Fahrenheit and Celsius.

## Features
- Monthly calendar view with weather data
- Custom cell templates showing icons and temperatures
- Temperature unit switcher (Fahrenheit/Celsius)
- Value converters for dynamic UI updates
- Interface-based data access for flexibility

## Technologies Used
- .NET MAUI
- Syncfusion Scheduler control
- XAML for UI layout
- C# for logic and data binding

## How It Works
1. A `WeatherForecast` model defines the structure for daily weather data.
2. The ViewModel generates sample weather data for a 3-month range.
3. The Scheduler control displays the calendar using a custom cell template.
4. Converters format weather icons and temperatures dynamically.
5. A ComboBox allows users to switch between temperature units.
6. An interface (`IWeatherProvider`) connects the ViewModel to the converter.

## Notes
- The weather data is static and for demo purposes only.
- You can extend this by integrating a real weather API.
- Make sure to explore Syncfusion's documentation for more customization options.

