using MauiApp1.Applications.Customers;
using MauiApp1.Models;
using Microsoft.Extensions.Logging;

namespace MauiApp1
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ICustomerAppService, CustomerAppService>();
            //builder.Services.AddSingleton<CustomerAppService>();
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}
