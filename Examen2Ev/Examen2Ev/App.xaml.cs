using System.Configuration;
using System.Data;
using System.Windows;
using Examen2Ev.Services;
using Examen2Ev.ViewModels;
using Examen2Ev.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Examen2Ev;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var settingsProvider = ConfigureServices();
        var window = settingsProvider.GetRequiredService<MainWindow>();
        window.DataContext = settingsProvider.GetRequiredService<MainViewModel>();
        window.Show();
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<MainWindow>();
        services.AddTransient<MainViewModel>();

        services.AddSingleton<ApiService>();

        return services.BuildServiceProvider();
    }
}