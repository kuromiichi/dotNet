using System.Configuration;
using System.Data;
using System.Windows;
using GestionEmpDepWPF.Services;
using GestionEmpDepWPF.ViewModels;
using GestionEmpDepWPF.Views;
using Microsoft.Extensions.DependencyInjection;

namespace GestionEmpDepWPF;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var serviceProvider = ConfigureServices();
        var window = serviceProvider.GetRequiredService<MainView>();
        window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
        window.Show();
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Services
        services.AddSingleton<DepartmentService>();
        services.AddSingleton<EmployeeService>();

        // Views
        services.AddSingleton<MainView>();
        services.AddSingleton<DepartmentsView>();
        services.AddSingleton<EmployeesView>();
        services.AddSingleton<GraphsView>();

        // ViewModels
        // he puesto transient pero al programa le da exactamente igual porque
        // como se crean una sola vez en el mainviewmodel son como singletons xd
        services.AddTransient<MainViewModel>();
        services.AddTransient<DepartmentsViewModel>();
        services.AddTransient<EmployeesViewModel>();
        services.AddTransient<GraphsViewModel>();

        return services.BuildServiceProvider();
    }
}