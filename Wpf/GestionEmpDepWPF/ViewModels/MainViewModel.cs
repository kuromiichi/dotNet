using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpDepWPF.Models;
using GestionEmpDepWPF.Services;

namespace GestionEmpDepWPF.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private object _activeView;

    private readonly DepartmentsViewModel _departmentsViewModel;
    private readonly EmployeesViewModel _employeesViewModel;
    private readonly GraphsViewModel _graphsViewModel;

    public MainViewModel(DepartmentsViewModel departmentsViewModel,
        EmployeesViewModel employeesViewModel,
        GraphsViewModel graphsViewModel,
        DepartmentService departmentService,
        EmployeeService employeeService)
    {
        _departmentsViewModel = departmentsViewModel;
        _employeesViewModel = employeesViewModel;
        _graphsViewModel = graphsViewModel;

        // TEST DEPARTMENTS
        departmentService.Add(new Department("Sistemas"));
        departmentService.Add(new Department("Contabilidad"));
        departmentService.Add(new Department("Administración"));
        
        // TEST EMPLOYEES
        employeeService.Add(new Employee("12345678A", "Alberto", "Calle 1", "123456789", "", "Sistemas", 1));
        employeeService.Add(new Employee("12345678B", "Carlos", "Calle 2", "123456789", "", "Contabilidad", 2));
        employeeService.Add(new Employee("12345678C", "Daniel", "Calle 3", "123456789", "", "Administración", 3));
        
        ActivateDepartmentsView();
    }

    [RelayCommand]
    private void ActivateDepartmentsView()
    {
        ActiveView = _departmentsViewModel;
        _departmentsViewModel.UpdateCollections();
    }

    [RelayCommand]
    private void ActivateEmployeesView()
    {
        ActiveView = _employeesViewModel;
        _employeesViewModel.UpdateCollections();
    }
    [RelayCommand]
    private void ActivateGraphsView()
    {
        ActiveView = _graphsViewModel;
        _graphsViewModel.UpdateCollections();
    }

    public string WindowTitle { get; } =
        "Departamentización de empleadura con graficación y base de presentación de ventanas";

    public string NavigationRadioButtonGroup { get; } = "nav";

    public string IconDepartments { get; } =
        "M7 16a1 1 0 1 0 0-2 1 1 0 0 0 0 2ZM8 18a1 1 0 1 1-2 0 1 1 0 0 1 2 0ZM7 13a1 1 0 1 0 0-2 1 1 0 0 0 0 2ZM8 9a1 1 0 1 1-2 0 1 1 0 0 1 2 0ZM7 7a1 1 0 1 0 0-2 1 1 0 0 0 0 2Z M14 4.25V5h4.75A2.25 2.25 0 0 1 21 7.25v13.5a.75.75 0 0 1-.75.75h-2.5a.5.5 0 0 1-.5-.5v-2.25a.5.5 0 0 0-.5-.5h-2.5a.5.5 0 0 0-.5.5V21a.5.5 0 0 1-.5.5h-9.5a.75.75 0 0 1-.75-.75V4.25A2.25 2.25 0 0 1 5.25 2h6.5A2.25 2.25 0 0 1 14 4.25ZM5.25 3.5a.75.75 0 0 0-.75.75V20H10V7.25A2.25 2.25 0 0 1 12.25 5h.25v-.75a.75.75 0 0 0-.75-.75h-6.5ZM18 15a1 1 0 1 0-2 0 1 1 0 0 0 2 0Zm-4 1a1 1 0 1 0 0-2 1 1 0 0 0 0 2Zm4-4a1 1 0 1 0-2 0 1 1 0 0 0 2 0Zm-4 1a1 1 0 1 0 0-2 1 1 0 0 0 0 2Zm4-4a1 1 0 1 0-2 0 1 1 0 0 0 2 0Zm-4 1a1 1 0 1 0 0-2 1 1 0 0 0 0 2Z";

    public string IconEmployees { get; } =
        "M4.249 13.995h5.876c-.349.423-.574.952-.62 1.53l-.009.22v4.5c0 .665.236 1.275.63 1.75l-.13.001c-3.42 0-5.943-1.072-7.486-3.236A2.75 2.75 0 0 1 2 17.164v-.92a2.249 2.249 0 0 1 2.249-2.249Zm10.497-2.5h3c.648 0 1.18.492 1.244 1.123l.007.127-.001 1.25h1.25c.967 0 1.75.784 1.75 1.75v4.5a1.75 1.75 0 0 1-1.75 1.75h-8a1.75 1.75 0 0 1-1.75-1.75v-4.5c0-.966.784-1.75 1.75-1.75h1.25v-1.25c0-.647.492-1.18 1.123-1.243l.127-.007h3-3Zm2.75 1.5h-2.5v1h2.5v-1ZM9.997 2a5 5 0 1 1 0 10 5 5 0 0 1 0-10Z";

    public string IconGraphs { get; } =
        "M10.25 4.25A.75.75 0 0 1 11 5v8h8a.75.75 0 0 1 .743.648l.007.102c0 4.97-4.03 8.5-9 8.5a9 9 0 0 1-9-9c0-4.97 3.53-9 8.5-9Zm3-2.5a9 9 0 0 1 9 9 .75.75 0 0 1-.75.75h-8.25a.75.75 0 0 1-.75-.75V2.5a.75.75 0 0 1 .75-.75Z";
}