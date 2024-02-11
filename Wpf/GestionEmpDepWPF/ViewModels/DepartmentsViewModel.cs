using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestionEmpDepWPF.Errors;
using GestionEmpDepWPF.Models;
using GestionEmpDepWPF.Services;

namespace GestionEmpDepWPF.ViewModels;

public partial class DepartmentsViewModel : ObservableObject

{
    private readonly DepartmentService _departmentService;
    private readonly EmployeeService _employeeService;

    [ObservableProperty] private ObservableCollection<Department> _departments;
    [ObservableProperty] private ObservableCollection<Employee> _employees;
    [ObservableProperty] private Department? _selectedDepartment;

    public DepartmentsViewModel(
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

    [ObservableProperty] private string _name;
    [ObservableProperty] private string _newName;

    [RelayCommand]
    private void DepartmentSelected(Department? department)
    {
        if (department is null) return;

        SelectedDepartment = department;
        Name = department.Name;
    }

    [RelayCommand]
    private void SaveDepartment()
    {
        if (SelectedDepartment is null || string.IsNullOrEmpty(Name)) return;

        var newDepartment = (SelectedDepartment.Clone() as Department)!;
        newDepartment.Name = Name;

        try
        {
            _departmentService.Update(newDepartment);
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
    private void DeleteDepartment()
    {
        if (SelectedDepartment is null) return;

        if (Employees.Any(e => e.DepartmentId == SelectedDepartment.Id))
        {
            MessageBox.Show(
                "El departamento no se puede borrar porque tiene empleados",
                "Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
            return;
        }

        _departmentService.Remove(SelectedDepartment.Id);
        UpdateCollections();

        Name = "";
        SelectedDepartment = null;
    }

    [RelayCommand]
    private void CreateDepartment()
    {
        if (string.IsNullOrEmpty(NewName)) return;

        try
        {
            _departmentService.Add(new Department(NewName));
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

        NewName = "";
        UpdateCollections();
    }
}