using Microsoft.Extensions.DependencyInjection;
using EasyShop.Views;

namespace EasyShop;

public partial class AppShell : Shell
{
    public AppShell(IServiceProvider services)
    {
        InitializeComponent();
        var tabs = new TabBar();
        tabs.Items.Add(new ShellContent
        {
            Title = "Produtos",
            ContentTemplate = new DataTemplate(() => services.GetRequiredService<ProductsPage>())
        });
        tabs.Items.Add(new ShellContent
        {
            Title = "Clientes",
            ContentTemplate = new DataTemplate(() => services.GetRequiredService<CustomersPage>())
        });
        Items.Add(tabs);
    }
}
