using Coffee_Shop.Services;
using Coffee_Shop.ViewModels;
using Coffee_Shop.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Coffee_Shop
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>().UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            AddProductService(builder.Services);
            return builder.Build();
        }
        private static IServiceCollection AddProductService(IServiceCollection services)
        {
            services.AddSingleton<ProductService>();
            services.AddTransientWithShellRoute<HomePage, HomeViewModel>(nameof(HomePage));
            services.AddTransientWithShellRoute<FoodPage, FoodViewModel>(nameof(FoodPage));
            services.AddTransientWithShellRoute<HotDrinkPage, HotDrinkViewModel>(nameof(HotDrinkPage));
            services.AddTransientWithShellRoute<ColdDrinkPage, ColdDrinkViewModel>(nameof(ColdDrinkPage));
            services.AddTransientWithShellRoute<AllProductPage, AllProductViewModel>(nameof(AllProductPage));
            services.AddTransientWithShellRoute<DetailPage, DetailViewModel>(nameof(DetailPage));
            services.AddScopedWithShellRoute<OrderPage, OrderViewModel>(nameof(OrderPage));
            services.AddScopedWithShellRoute<OrderSummary, OrderSummaryViewModel>(nameof(OrderSummary));
            services.AddScopedWithShellRoute<DailyOrder, DailyOrderViewModel>(nameof(DailyOrder));
            return services;
        }
    }
}
