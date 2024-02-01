using Navegacion.Core;

namespace Navegacion.ViewModels;

public class MainViewModel : ObservableObject
{
    private object _activeView;

    public object ActiveView
    {
        get => _activeView;
        set
        {
            _activeView = value;
            OnPropertyChanged();
        }
    }

    public DepartmentsViewModel DepartmentsViewModel { get; set; }
    public EmployeesViewModel EmployeesViewModel { get; set; }
    public SettingsViewModel SettingsViewModel { get; set; }

    public RelayCommand ActivateDepartmentsViewCommand { get; set; }
    public RelayCommand ActivateEmployeesViewCommand { get; set; }
    public RelayCommand ActivateSettingsViewCommand { get; set; }

    public MainViewModel()
    {
        DepartmentsViewModel = new();
        EmployeesViewModel = new();
        SettingsViewModel = new();

        _activeView = DepartmentsViewModel;
        
        ActivateDepartmentsViewCommand = new RelayCommand(o => ActiveView = DepartmentsViewModel);
        ActivateEmployeesViewCommand = new RelayCommand(o => ActiveView = EmployeesViewModel);
        ActivateSettingsViewCommand = new RelayCommand(o => ActiveView = SettingsViewModel);
    }
}