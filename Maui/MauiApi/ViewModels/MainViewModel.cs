using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApi.Models;
using MauiApi.Services;
using System.Collections.ObjectModel;

namespace MauiApi.ViewModels;

partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Dog> _dogs;

    [RelayCommand]
    private void GetDogs()
    {
        LoadData();
    }

    private static MainViewModel _instance;

    public MainViewModel()
    {
        _instance = this;
        DetectApiKey();
        LoadData();
    }

    private async void LoadData()
    {
        var dogService = new DogService();
        await dogService.GetDogs();
        Dogs = new ObservableCollection<Dog>(dogService.Dogs);
    }

    [ObservableProperty]
    private bool _isApiKeySet;

    [ObservableProperty]
    private bool _isApiKeyNotSet;

    public static void DetectApiKey()
    {
        _instance.IsApiKeySet = !string.IsNullOrEmpty(Preferences.Default.Get("ApiKey", string.Empty));
        _instance.IsApiKeyNotSet = !_instance.IsApiKeySet;
        if (_instance.IsApiKeySet) _instance.LoadData();
    }
}
