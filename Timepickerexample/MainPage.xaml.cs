using Microsoft.Maui.Controls;

namespace Timepickerexample
{
    public partial class MainPage : ContentPage
    {
        public TimeSpan SelectedTime { get; set; }

        public MainPage()
            {
            InitializeComponent();
            BindingContext = this;

            // Set initial time
            SelectedTime = new TimeSpan(14, 30, 0); // Example: 2:30 PM
            }
        }
}
