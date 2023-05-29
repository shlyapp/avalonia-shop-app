using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ShopApp.Views.Pages;

public partial class ShopPageView : UserControl
{
    public ShopPageView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}