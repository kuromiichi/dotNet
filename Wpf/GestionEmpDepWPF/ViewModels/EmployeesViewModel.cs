using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpDepWPF.Errors;
using GestionEmpDepWPF.Models;
using GestionEmpDepWPF.Services;
using GestionEmpDepWPF.Validators;
using GestionEmpDepWPF.Views;
using Microsoft.Extensions.DependencyInjection;

namespace GestionEmpDepWPF.ViewModels;

public partial class EmployeesViewModel : ObservableObject
{
    private readonly DepartmentService _departmentService;
    private readonly EmployeeService _employeeService;

    [ObservableProperty] private ObservableCollection<Department> _departments;
    [ObservableProperty] private ObservableCollection<Employee> _employees;
    [ObservableProperty] private Employee? _selectedEmployee;

    public EmployeesViewModel(
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
    private void EmployeeSelected(Employee? employee)
    {
        if (employee is null) return;

        SelectedEmployee = employee;
        Dni = employee.Dni;
        Name = employee.Name;
        Email = employee.Email;
        Phone = employee.Phone;
        PhotoUri = employee.PhotoUri;
        Position = employee.Position;
        Department = _departmentService.Get((long)employee.DepartmentId!);
    }

    [RelayCommand]
    private void SaveEmployee()
    {
        if (SelectedEmployee is null) return;

        var newEmployee = (SelectedEmployee.Clone() as Employee)!;
        newEmployee.Name = Name;
        newEmployee.Email = Email;
        newEmployee.Phone = Phone;
        newEmployee.PhotoUri = PhotoUri;
        newEmployee.Position = Position;
        newEmployee.DepartmentId = Department?.Id;

        try
        {
            _employeeService.Update(newEmployee);
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

        UpdateCollections();
    }

    [RelayCommand]
    private void DeleteEmployee()
    {
        if (SelectedEmployee is null) return;

        try
        {
            _employeeService.Remove(SelectedEmployee.Dni);
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

        UpdateCollections();
        
        Dni = "";
        Name = "";
        Email = "";
        Phone = "";
        PhotoUri = "";
        Position = "";
        Department = null;
    }

    [RelayCommand]
    private void CreateEmployee()
    {
        var createEmployeeWindow = new CreateEmployeeView();
        var createEmployeeViewModel = new CreateEmployeeViewModel(_departmentService, _employeeService);
        createEmployeeWindow.DataContext = createEmployeeViewModel;
        createEmployeeViewModel.CloseRequested += () =>
        {
            createEmployeeWindow.Close();
            UpdateCollections();
        };
        createEmployeeWindow.ShowDialog();
    }
}