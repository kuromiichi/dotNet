using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Examen2Ev.Models;
using Examen2Ev.Services;

namespace Examen2Ev.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ApiService _apiService;

    [ObservableProperty] private ObservableCollection<Artist> _artists;
    [ObservableProperty] private ObservableCollection<Painting> _paintings;

    [ObservableProperty] private Artist _selectedArtist;
    [ObservableProperty] private Painting _selectedPainting;

    [ObservableProperty] private string _image;

    public MainViewModel(ApiService apiService)
    {
        _apiService = apiService;

        GetArtists();
    }

    private async Task GetArtists()
    {
        var artists = await _apiService.GetArtists();
        Artists = new ObservableCollection<Artist>(artists);
    }

    [RelayCommand]
    private async Task Filter()
    {
        if (SelectedArtist == null) return;

        var paintings = await _apiService.GetPaintings(SelectedArtist.Id);
        Paintings = new ObservableCollection<Painting>(paintings);
    }

    partial void OnSelectedPaintingChanged(Painting value)
    {
        string baseUrl = "http://192.168.16.117:7777";
        Image = baseUrl + SelectedPainting.File;
    }
}