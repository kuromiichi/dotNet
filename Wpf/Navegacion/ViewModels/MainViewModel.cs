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

    public string NavigationRadioButtonGroup { get; } = "NavigationRadioButtonGroup";
    
    public string IconDepartments { get; } =
        "M7 16a1 1 0 1 0 0-2 1 1 0 0 0 0 2ZM8 18a1 1 0 1 1-2 0 1 1 0 0 1 2 0ZM7 13a1 1 0 1 0 0-2 1 1 0 0 0 0 2ZM8 9a1 1 0 1 1-2 0 1 1 0 0 1 2 0ZM7 7a1 1 0 1 0 0-2 1 1 0 0 0 0 2Z M14 4.25V5h4.75A2.25 2.25 0 0 1 21 7.25v13.5a.75.75 0 0 1-.75.75h-2.5a.5.5 0 0 1-.5-.5v-2.25a.5.5 0 0 0-.5-.5h-2.5a.5.5 0 0 0-.5.5V21a.5.5 0 0 1-.5.5h-9.5a.75.75 0 0 1-.75-.75V4.25A2.25 2.25 0 0 1 5.25 2h6.5A2.25 2.25 0 0 1 14 4.25ZM5.25 3.5a.75.75 0 0 0-.75.75V20H10V7.25A2.25 2.25 0 0 1 12.25 5h.25v-.75a.75.75 0 0 0-.75-.75h-6.5ZM18 15a1 1 0 1 0-2 0 1 1 0 0 0 2 0Zm-4 1a1 1 0 1 0 0-2 1 1 0 0 0 0 2Zm4-4a1 1 0 1 0-2 0 1 1 0 0 0 2 0Zm-4 1a1 1 0 1 0 0-2 1 1 0 0 0 0 2Zm4-4a1 1 0 1 0-2 0 1 1 0 0 0 2 0Zm-4 1a1 1 0 1 0 0-2 1 1 0 0 0 0 2Z";

    public string IconEmployees { get; } =
        "M4.249 13.995h5.876c-.349.423-.574.952-.62 1.53l-.009.22v4.5c0 .665.236 1.275.63 1.75l-.13.001c-3.42 0-5.943-1.072-7.486-3.236A2.75 2.75 0 0 1 2 17.164v-.92a2.249 2.249 0 0 1 2.249-2.249Zm10.497-2.5h3c.648 0 1.18.492 1.244 1.123l.007.127-.001 1.25h1.25c.967 0 1.75.784 1.75 1.75v4.5a1.75 1.75 0 0 1-1.75 1.75h-8a1.75 1.75 0 0 1-1.75-1.75v-4.5c0-.966.784-1.75 1.75-1.75h1.25v-1.25c0-.647.492-1.18 1.123-1.243l.127-.007h3-3Zm2.75 1.5h-2.5v1h2.5v-1ZM9.997 2a5 5 0 1 1 0 10 5 5 0 0 1 0-10Z";

    public string IconSettings { get; } =
        "M12.012 2.25c.734.008 1.465.093 2.182.253a.75.75 0 0 1 .582.649l.17 1.527a1.384 1.384 0 0 0 1.927 1.116l1.401-.615a.75.75 0 0 1 .85.174 9.792 9.792 0 0 1 2.204 3.792.75.75 0 0 1-.271.825l-1.242.916a1.381 1.381 0 0 0 0 2.226l1.243.915a.75.75 0 0 1 .272.826 9.797 9.797 0 0 1-2.204 3.792.75.75 0 0 1-.848.175l-1.407-.617a1.38 1.38 0 0 0-1.926 1.114l-.169 1.526a.75.75 0 0 1-.572.647 9.518 9.518 0 0 1-4.406 0 .75.75 0 0 1-.572-.647l-.168-1.524a1.382 1.382 0 0 0-1.926-1.11l-1.406.616a.75.75 0 0 1-.849-.175 9.798 9.798 0 0 1-2.204-3.796.75.75 0 0 1 .272-.826l1.243-.916a1.38 1.38 0 0 0 0-2.226l-1.243-.914a.75.75 0 0 1-.271-.826 9.793 9.793 0 0 1 2.204-3.792.75.75 0 0 1 .85-.174l1.4.615a1.387 1.387 0 0 0 1.93-1.118l.17-1.526a.75.75 0 0 1 .583-.65c.717-.159 1.45-.243 2.201-.252ZM12 9a3 3 0 1 0 0 6 3 3 0 0 0 0-6Z";


    public MainViewModel()
    {
        DepartmentsViewModel = new();
        EmployeesViewModel = new();
        SettingsViewModel = new();

        _activeView = DepartmentsViewModel;

        ActivateDepartmentsViewCommand = new RelayCommand(_ => ActiveView = DepartmentsViewModel);
        ActivateEmployeesViewCommand = new RelayCommand(_ => ActiveView = EmployeesViewModel);
        ActivateSettingsViewCommand = new RelayCommand(_ => ActiveView = SettingsViewModel);
    }
}