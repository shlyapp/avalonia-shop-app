using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
using ReactiveUI;
using ShopApp.ViewModels.Pages;

namespace ShopApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static MainWindowViewModel _instanse;
    private ViewModelBase _currentPage;

    private MainWindowViewModel()
    {
        _shopPage = new ShopPageViewModel();
        _shoppingCartPage = new ShoppingCartPageViewModel();

        CurrentPage = _shopPage;

        ClickInNavigationButton = ReactiveCommand.Create<string>(ChangeCurrentPage);

        ButtonColors = new ObservableCollection<SolidColorBrush>()
        {
            new SolidColorBrush(Colors.Transparent),
            new SolidColorBrush(Color.Parse("#D2D59A")),
            new SolidColorBrush(Colors.Transparent),
        };
    }

    public ShopPageViewModel _shopPage; 
    public ShoppingCartPageViewModel _shoppingCartPage;

    public ReactiveCommand<string, Unit> ClickInNavigationButton { get; }
    
    public ObservableCollection<SolidColorBrush> ButtonColors { get; set; }

    public void ChangeCurrentPage(string parameter)
    {
        switch (parameter)
        {
            case "Товары":
                CurrentPage = _shopPage;
                ButtonColors[0] = new SolidColorBrush(Colors.Transparent);
                ButtonColors[1] = new SolidColorBrush(Color.Parse("#D2D59A"));
                ButtonColors[2] = new SolidColorBrush(Colors.Transparent);
                break;
            case "Корзина":
                CurrentPage = _shoppingCartPage;
                ButtonColors[0] = new SolidColorBrush(Colors.Transparent);
                ButtonColors[1] = new SolidColorBrush(Colors.Transparent);
                ButtonColors[2] = new SolidColorBrush(Color.Parse("#D2D59A"));
                break;
        }
    }
    
    public static MainWindowViewModel Instanse
    {
        get
        {
            if (_instanse == null)
            {
                _instanse = new MainWindowViewModel();
            }

            return _instanse;
        }
    }

    public ViewModelBase CurrentPage
    {
        get
        {
            return _currentPage;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _currentPage, value);
        }
    }
}