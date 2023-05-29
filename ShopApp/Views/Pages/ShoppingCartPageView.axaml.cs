using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ShopApp.Views.Pages;

public partial class ShoppingCartPageView : UserControl
{
    public ShoppingCartPageView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}