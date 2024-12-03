using Android.App;
using Android.Content;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace Timepickerexample;

public class CustomTimePickerHandler : TimePickerHandler
    {
    protected override TimePickerDialog CreateTimePickerDialog(int hour, int minute)
        {
        var context = MauiContext?.Context;
        if (context == null)
            throw new InvalidOperationException("Context is null");

        // Use Spinner style for TimePickerDialog
        return new TimePickerDialog(context, Android.Resource.Style.ThemeHoloLightDialogNoActionBar, OnTimeSet, hour, minute, true);
        }

    private void OnTimeSet(object? sender, TimePickerDialog.TimeSetEventArgs e)
        {
        if (VirtualView != null)
            {
            VirtualView.Time = new TimeSpan(e.HourOfDay, e.Minute, 0);
            }
        }
    }
