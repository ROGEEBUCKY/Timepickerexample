using Android.Content;
using Android.OS;
using Android.Widget;

public static class TimePickerExtensions
    {
    public static void SetIsSpinnerMode(this Android.Widget.TimePicker timePicker, bool useSpinner)
        {
        if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop && Build.VERSION.SdkInt <= BuildVersionCodes.M)
            {
            try
                {
                // Using reflection to access private properties
                var classType = Java.Lang.Class.FromType(typeof(Android.Widget.TimePicker));
                var field = classType.GetDeclaredField("mDelegate");
                field.Accessible = true;

                var delegateInstance = field.Get(timePicker);
                var spinnerClassName = "android.widget.TimePickerSpinnerDelegate";

                if (delegateInstance.Class.Name != spinnerClassName)
                    {
                    var constructor = Java.Lang.Class.ForName(spinnerClassName)
                        .GetDeclaredConstructor(
                            Java.Lang.Class.FromType(typeof(Android.Widget.TimePicker)),
                            Java.Lang.Class.FromType(typeof(Context)),
                            Java.Lang.Class.FromType(typeof(int)));
                    constructor.Accessible = true;
                    var spinnerDelegate = constructor.NewInstance(timePicker, timePicker.Context, Android.Resource.Style.WidgetMaterialTimePicker);
                    field.Set(timePicker, spinnerDelegate);
                    }
                }
            catch (Exception ex)
                {
                Console.WriteLine($"Error setting spinner mode: {ex.Message}");
                }
            }
        }
    }
