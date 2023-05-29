using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class PurshareWindow : Window
{
    public PurshareWindow(bool result, double money)
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        this.DataContext = new PurshareWindowViewModel(result, money);
    }

    public PurshareWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}