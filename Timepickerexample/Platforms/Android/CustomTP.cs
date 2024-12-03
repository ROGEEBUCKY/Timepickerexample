using Android.Content;
using Android.Widget;
using Microsoft.Maui.Handlers;

namespace Timepickerexample
    {
    public class InlineTimePickerHandler : ViewHandler<InlineTimePicker, LinearLayout>
        {
        private bool _isUpdating;
        public static IPropertyMapper<InlineTimePicker, InlineTimePickerHandler> PropertyMapper = new PropertyMapper<InlineTimePicker, InlineTimePickerHandler>(ViewHandler.ViewMapper)
            {

            };

        public InlineTimePickerHandler() : base(PropertyMapper)
            {
            }
        protected override LinearLayout CreatePlatformView()
            {
            var context = MauiContext?.Context ?? throw new InvalidOperationException("Context is null");

            var layout = new LinearLayout(context)
                {
                Orientation = Orientation.Horizontal
                };

            // Create hour picker
            var hourPicker = new NumberPicker(context)
                {
                MinValue = 0,
                MaxValue = 23
                };
            hourPicker.ValueChanged += (s, e) =>
            {
                if (_isUpdating) return;

                _isUpdating = true;
                var newTime = new TimeSpan(hourPicker.Value, VirtualView.Time.Minutes, 0);
                VirtualView.OnTimeChanged(newTime);
                _isUpdating = false;
            };

            // Create minute picker
            var minutePicker = new NumberPicker(context)
                {
                MinValue = 0,
                MaxValue = 59
                };
            minutePicker.ValueChanged += (s, e) =>
            {
                if (_isUpdating) return;

                _isUpdating = true;
                var newTime = new TimeSpan(VirtualView.Time.Hours, minutePicker.Value, 0);
                VirtualView.OnTimeChanged(newTime);
                _isUpdating = false;
            };

            layout.AddView(hourPicker);
            layout.AddView(minutePicker);

            return layout;
            }

        protected override void ConnectHandler(LinearLayout platformView)
            {
            base.ConnectHandler(platformView);

            if (VirtualView != null)
                {
                UpdateTime();
                }
            }

        private void UpdateTime()
            {
            if (PlatformView == null) return;

            _isUpdating = true;

            var hourPicker = (NumberPicker)PlatformView.GetChildAt(0);
            var minutePicker = (NumberPicker)PlatformView.GetChildAt(1);

            hourPicker.Value = VirtualView.Time.Hours;
            minutePicker.Value = VirtualView.Time.Minutes;

            _isUpdating = false;
            }
        }
    }
