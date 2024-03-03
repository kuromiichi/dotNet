using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApi.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MauiApi.Models.Dog;

namespace MauiApi.ViewModels;

partial class BreedsViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Breed> _breeds;

    [ObservableProperty]
    private Breed? _selectedBreed;

    private string _searchText;
    public string SearchText
    {
        get { return _searchText; }
        set
        {
            _searchText = value;

            if (string.IsNullOrEmpty(_searchText))
            {
                Breeds = new ObservableCollection<Breed>(AllBreeds);
            }
            else
            {
                Breeds = new ObservableCollection<Breed>(AllBreeds
                    .Where(x => x.Name.Contains(_searchText, StringComparison.OrdinalIgnoreCase)));
            }
        }
    }

    private List<Breed> _allBreeds;
    private List<Breed> AllBreeds
    {
        get { return _allBreeds; }
        set
        {
            _allBreeds = value;
            SearchText = string.Empty;
        }
    }

    [RelayCommand]
    private async void BreedSelected()
    {
        if (SelectedBreed == null) return;

        System.Diagnostics.Debug.WriteLine($"SELECTION CHANGED: {SelectedBreed.Name}");
        var parameter = new Dictionary<string, object> { { "Breed", SelectedBreed } };
        await Shell.Current.GoToAsync("breeddetails", parameter);
        SelectedBreed = null;
    }

    public BreedsViewModel()
    {
        LoadData();
    }

    private async void LoadData()
    {
        var dogService = new DogService();
        await dogService.GetBreeds();
        AllBreeds = dogService.Breeds;
    }
}
