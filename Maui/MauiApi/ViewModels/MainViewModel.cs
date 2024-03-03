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

    public MainViewModel()
    {
        LoadData();
    }

    private async void LoadData()
    {
        var dogService = new DogService();
        await dogService.GetDogs();
        Dogs = new ObservableCollection<Dog>(dogService.Dogs);
    }
}
