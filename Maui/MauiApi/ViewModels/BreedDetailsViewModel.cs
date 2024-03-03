using CommunityToolkit.Mvvm.ComponentModel;
using MauiApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MauiApi.Models.Dog;

namespace MauiApi.ViewModels;

[QueryProperty(nameof(Breed), "Breed")]
partial class BreedDetailsViewModel : ObservableObject
{
    [ObservableProperty]
    private Breed _breed;

    [ObservableProperty]
    private string _breedImage;

    public BreedDetailsViewModel()
    {
        LoadData();
    }

    private async void LoadData()
    {
        while (Breed == null)
        {
            await Task.Delay(100);
        }

        var dogService = new DogService();
        BreedImage = await dogService.GetBreedImage(Breed.Id);
    }
}
