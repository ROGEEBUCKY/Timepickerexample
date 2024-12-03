using Microsoft.Maui.Controls;

namespace Timepickerexample
    {
    public class CustomTimePicker : View
        {
        public static readonly BindableProperty SelectedTimeProperty =
            BindableProperty.Create(nameof(SelectedTime), typeof(TimeSpan), typeof(CustomTimePicker), default(TimeSpan), BindingMode.TwoWay);

        public TimeSpan SelectedTime
            {
            get => (TimeSpan)GetValue(SelectedTimeProperty);
            set => SetValue(SelectedTimeProperty, value);
            }
        }
    }
