using Syncfusion.Maui.Inputs;

namespace ForecastMAUI
{
    public class ForecastBehaviors : Behavior<SfComboBox>
    {
        private SfComboBox? _comboBox;
        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            if (bindable is SfComboBox comboBox)
            {
                _comboBox = comboBox;
                _comboBox.SelectionChanged += ForecastBehaviors_SelectionChanged;
            }
        }

        private void ForecastBehaviors_SelectionChanged(object? sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
        {
            if (_comboBox != null && _comboBox.BindingContext is WeatherForecastViewModel viewModel && e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var selectedUnit = e.AddedItems[0]?.ToString();
                if (!string.IsNullOrEmpty(selectedUnit))
                {
                    viewModel.SelectedTemperatureUnitString = selectedUnit;

                    //// Refresh month view 
                    if (selectedUnit != "Fahrenheit")
                    {
                        viewModel.SelectedDate = DateTime.Now.Date;
                    }
                    else
                    {
                        viewModel.SelectedDate = viewModel.SelectedDate.AddDays(1);
                    }
                }
            }
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            if(_comboBox != null)
            {
                _comboBox.SelectionChanged -= ForecastBehaviors_SelectionChanged;
            }
        }
    }
}
