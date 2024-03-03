using MauiApi.Views;

namespace MauiApi;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        RegisterRoutes();
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute("dogdetails", typeof(DogDetailsPage));
        Routing.RegisterRoute("breeddetails", typeof(BreedDetailsPage));
    }
}