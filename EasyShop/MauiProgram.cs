using Microsoft.Extensions.Logging;
using EasyShop.Data.Repositories;

namespace EasyShop;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>();

        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<IProductRepository, LiteDbProductRepository>();
        builder.Services.AddSingleton<ICustomerRepository, SqliteCustomerRepository>();
        builder.Services.AddSingleton<ProductService>();
        builder.Services.AddSingleton<CustomerService>();
        builder.Services.AddTransient<ProductsViewModel>();
        builder.Services.AddTransient<CustomersViewModel>();
        builder.Services.AddTransient<ProductsPage>();
        builder.Services.AddTransient<CustomersPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
