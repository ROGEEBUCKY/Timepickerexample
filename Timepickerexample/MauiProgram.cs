using Microsoft.Extensions.Logging;

namespace Timepickerexample
    {
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                 .ConfigureMauiHandlers(handlers =>
                 {
                     handlers.AddHandler<TimePicker, CustomTimePickerHandler>();
                 });
                 //.ConfigureMauiHandlers(handlers =>
                 //{
                 //    handlers.AddHandler<CustomTimePicker, CustomEmbeddedTimePickerHandler>();
                 //});

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
