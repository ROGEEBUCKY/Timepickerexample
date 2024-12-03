
using Microsoft.Maui.Handlers;

namespace Timepickerexample
    {
    public class CustomEmbeddedTimePickerHandler : ViewHandler<CustomTimePicker, Android.Widget.TimePicker>
        {
        public CustomEmbeddedTimePickerHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null)
            : base(mapper, commandMapper)
            {
            }

        protected override Android.Widget.TimePicker CreatePlatformView()
            {
            var timePicker = new Android.Widget.TimePicker(Context);

            // Set the TimePicker to 24-hour format and spinner mode
            timePicker.SetIs24HourView(Java.Lang.Boolean.True);

            // Set initial time
            var time = VirtualView.SelectedTime;
            timePicker.Hour = time.Hours;
            timePicker.Minute = time.Minutes;

            // Update the binding whenever the time changes
            timePicker.TimeChanged += (s, e) =>
            {
                if (VirtualView != null)
                    {
                    var newTime = new TimeSpan(timePicker.Hour, timePicker.Minute, 0);
                    VirtualView.SelectedTime = newTime;
                    }
            };

            return timePicker;
            }

        protected override void ConnectHandler(Android.Widget.TimePicker platformView)
            {
            base.ConnectHandler(platformView);
            }

        protected override void DisconnectHandler(Android.Widget.TimePicker platformView)
            {
            platformView.TimeChanged -= (s, e) => { }; // Cleanup event handlers
            base.DisconnectHandler(platformView);
            }
        }
    }
