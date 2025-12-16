using Microsoft.Extensions.Logging;
using MAUIStatsApi.DTO;
using MAUIStatsApi.View;
using MAUIStatsApi.ViewModel;

namespace MAUIStatsApi
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
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<PlayersPage>();
            builder.Services.AddTransient<PlayerDetailsPage>();

            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<PlayersViewModel>();
            builder.Services.AddTransient<PlayerDetailsViewModel>();
#endif

            return builder.Build();
        }
    }
}
