using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GestionEmpDepWPF.CustomControls;

public partial class IconButton : UserControl
{
    public static readonly DependencyProperty SvgDataProperty =
        DependencyProperty.Register("SvgData", typeof(string), typeof(IconButton));
    
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(IconButton));
    
    public static readonly DependencyProperty RadioButtonGroupProperty =
        DependencyProperty.Register("RadioButtonGroup", typeof(string), typeof(IconButton));
    
    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(IconButton));
    
    public string SvgData
    {
        get => (string)GetValue(SvgDataProperty);
        set => SetValue(SvgDataProperty, value);
    }
    
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public string RadioButtonGroup
    {
        get => (string)GetValue(RadioButtonGroupProperty);
        set => SetValue(RadioButtonGroupProperty, value);
    }
    
    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }
    
    public IconButton() => InitializeComponent();

    private void Border_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        RadioButton.IsChecked = true;
        ICommand command = Command;
        if (command != null && command.CanExecute(null)) command.Execute(null);
    }
}