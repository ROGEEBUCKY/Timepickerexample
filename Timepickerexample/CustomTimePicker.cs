using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace Timepickerexample
    {
    public class InlineTimePicker : VerticalStackLayout
        {
        public TimeSpan Time { get; set; } = new TimeSpan(0, 0, 0);

        public event EventHandler<TimeSpan> TimeChanged;

        public void OnTimeChanged(TimeSpan time)
            {
            Time = time;
            TimeChanged?.Invoke(this, Time);
            }
        }
    }
