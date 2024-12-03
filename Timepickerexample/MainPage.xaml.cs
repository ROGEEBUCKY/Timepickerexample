using Microsoft.Maui.Controls;

namespace Timepickerexample
{
    public partial class MainPage : ContentPage
        {

        public MainPage()
            {
            InitializeComponent();
            var timePicker = new InlineTimePicker();
            timePicker.TimeChanged += (s, e) =>
            {
                Console.WriteLine($"Selected Time: {e}");
            };
            }
        }
}
