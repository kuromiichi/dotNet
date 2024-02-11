using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using GestionEmpDepWPF.Models;
using GestionEmpDepWPF.Services;
using LiveCharts;
using LiveCharts.Wpf;

namespace GestionEmpDepWPF.ViewModels;

public partial class GraphsViewModel : ObservableObject
{
    private readonly DepartmentService _departmentService;
    private readonly EmployeeService _employeeService;
    
    [ObservableProperty] private ObservableCollection<Department> _departments;
    [ObservableProperty] private ObservableCollection<Employee> _employees;

    public GraphsViewModel(
        DepartmentService departmentService,
        EmployeeService employeeService
    )
    {
        _departmentService = departmentService;
        _employeeService = employeeService;
        
        UpdateCollections();
    }
    
    public void UpdateCollections()
    {
        Departments = new ObservableCollection<Department>(_departmentService.GetAll());
        Employees = new ObservableCollection<Employee>(_employeeService.GetAll());
        Series = CreateSeries();
    }

    public string Title { get; } = "Empleados por departamento";

    public SeriesCollection Series { get; set; }

    private SeriesCollection CreateSeries()
    {
        var series = new SeriesCollection();

        var employeesPerDepartment = Employees.GroupBy(e => e.DepartmentId)
            .ToDictionary(g => g.Key, g => g.Count());

        foreach (var departmentId in employeesPerDepartment.Keys)
        {
            series.Add(new PieSeries
            {
                Title = Departments.First(d => d.Id == departmentId).Name,
                Values = new ChartValues<int> { employeesPerDepartment[departmentId] },
            });
        }

        return series;
    }
}