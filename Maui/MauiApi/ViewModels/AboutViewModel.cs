using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApi.ViewModels;

public partial class AboutViewModel : ObservableObject
{
    [RelayCommand]
    private async void OpenGitHub()
    {
        await Launcher.TryOpenAsync("https://github.com/kuromiichi");
    }
}