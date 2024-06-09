using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using parcial2.Services;
using parcial2.Pages;
using parcial2.ViewModels;

namespace parcial2
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
                }).UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            AddPizzaServices(builder.Services);

            return builder.Build();
        }
        private static IServiceCollection AddPizzaServices(IServiceCollection services)
        {
            services.AddSingleton<PizzaService>();
            services.AddSingleton<HomePage>()
                .AddSingleton<HomeViewModel>();

            services.AddTransientWithShellRoute<DetailPage, DetailsViewModel>(nameof(DetailPage));
            services.AddSingleton<CartViewModel>();
            services.AddSingleton<CartPage>();

            return services;
        }
    }
}
