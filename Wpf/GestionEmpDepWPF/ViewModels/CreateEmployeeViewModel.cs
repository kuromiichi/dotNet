using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpDepWPF.Errors;
using GestionEmpDepWPF.Models;
using GestionEmpDepWPF.Services;
using GestionEmpDepWPF.Validators;

namespace GestionEmpDepWPF.ViewModels;

public partial class CreateEmployeeViewModel : ObservableObject
{
    private readonly DepartmentService _departmentService;
    private readonly EmployeeService _employeeService;

    [ObservableProperty] private ObservableCollection<Department> _departments;
    [ObservableProperty] private ObservableCollection<Employee> _employees;
    
    public event Action? CloseRequested;

    public CreateEmployeeViewModel(
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
    }

    [ObservableProperty] private string _dni;
    [ObservableProperty] private string _name;
    [ObservableProperty] private string _email;
    [ObservableProperty] private string _phone;
    [ObservableProperty] private string _photoUri;
    [ObservableProperty] private Department? _department;
    [ObservableProperty] private string _position;

    [RelayCommand]
    public void CreateEmployee()
    {
        var newEmployee = new Employee(Dni, Name, Email, Phone, PhotoUri, Position, Department?.Id);

        string validation = EmployeeValidator.ValidateEmployee(newEmployee);
        if (validation != "OK")
        {
            MessageBox.Show(
                validation,
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
            return;
        }

        try
        {
            _employeeService.Add(newEmployee);
            CloseRequested?.Invoke();
        }
        catch (GestionEmpDepWPFException e)
        {
            MessageBox.Show(
                e.Message,
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }
}