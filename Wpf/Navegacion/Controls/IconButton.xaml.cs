using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Navegacion.Controls;

public partial class IconButton : UserControl
{
    public static readonly DependencyProperty GroupNameProperty =
        DependencyProperty.Register("GroupName", typeof(string), typeof(IconButton));
    
    public static readonly DependencyProperty IsCheckedProperty =
        DependencyProperty.Register("IsChecked", typeof(bool), typeof(IconButton));
    
    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(IconButton));
    
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(string), typeof(IconButton));
    
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(IconButton));
    
    public string GroupName
    {
        get => (string)GetValue(GroupNameProperty);
        set => SetValue(GroupNameProperty, value);
    }
    
    public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }
    
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
    
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public IconButton() => InitializeComponent();

    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        IsChecked = !IsChecked;
    }
}