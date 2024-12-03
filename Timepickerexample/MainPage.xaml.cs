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
        private void OnGetTimeClicked(object sender, EventArgs e)
            {
            var selectedTime = InlineTimePicker.Time; // Get the selected time
            DisplayAlert("Selected Time", $"You selected: {selectedTime:hh\\:mm}", "OK");
            }
        }
}
