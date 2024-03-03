using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApi.ViewModels;

partial class SettingsViewModel : ObservableObject
{
    [ObservableProperty]
    private string _apiKey;

    [ObservableProperty]
    private int _dogNumber;

    [RelayCommand]
    private async void GetApiKey()
    {
        await Launcher.TryOpenAsync("http://www.thedogapi.com/signup");
    }

    [RelayCommand]
    private void Save()
    {
        Preferences.Default.Set("ApiKey", ApiKey);
        Preferences.Default.Set("DogNumber", DogNumber);
        Toast.Make("Ajustes guardados", ToastDuration.Short).Show();
    }

    public SettingsViewModel()
    {
        ApiKey = Preferences.Default.Get("ApiKey", string.Empty);
        DogNumber = Preferences.Default.Get("DogNumber", 5);
    }

}
