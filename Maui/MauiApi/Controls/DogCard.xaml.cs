namespace MauiApi.Controls;

public partial class DogCard : ContentView
{
    public static readonly BindableProperty ImageProperty =
        BindableProperty.Create(nameof(Image), typeof(ImageSource), typeof(DogCard));

    public static readonly BindableProperty BreedNameProperty =
        BindableProperty.Create(nameof(BreedName), typeof(string), typeof(DogCard));

    public ImageSource Image
    {
        get => (ImageSource)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }

    public string BreedName
    {
        get => (string)GetValue(BreedNameProperty);
        set => SetValue(BreedNameProperty, value);
    }

    public DogCard() => InitializeComponent();
}