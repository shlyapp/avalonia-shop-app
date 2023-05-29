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
    /// <summary>
    /// Для паттерна одиночка
    /// </summary>
    private static MainWindowViewModel _instanse;
    
    /// <summary>
    /// Текушая отображаемая страница
    /// </summary>
    private ViewModelBase _currentPage;

    private MainWindowViewModel()
    {
        // Создаем страницы
        ShopPage = new ShopPageViewModel();
        ShoppingCartPage = new ShoppingCartPageViewModel();

        // Задаем текущую страницу
        CurrentPage = ShopPage;

        // Команда для перехода между страницами
        ClickInNavigationButton = ReactiveCommand.Create<string>(ChangeCurrentPage);
        
        ButtonColors = new ObservableCollection<SolidColorBrush>()
        {
            new SolidColorBrush(Color.Parse("#D2D59A")),
            new SolidColorBrush(Colors.Transparent),
        };
    }

    // Наши страницы
    public ShopPageViewModel ShopPage; 
    public ShoppingCartPageViewModel ShoppingCartPage;
    
    public ReactiveCommand<string, Unit> ClickInNavigationButton { get; }
    
    // Цвета для кнопки активной страницы
    public ObservableCollection<SolidColorBrush> ButtonColors { get; set; }

    /// <summary>
    /// Смена страницы
    /// </summary>
    /// <param name="parameter">Название кнопки</param>
    public void ChangeCurrentPage(string parameter)
    {
        // В зависимости от названия кнопки меняем страницу
        switch (parameter)
        {
            case "Товары":
                CurrentPage = ShopPage;
                ButtonColors[0] = new SolidColorBrush(Color.Parse("#D2D59A"));
                ButtonColors[1] = new SolidColorBrush(Colors.Transparent);
                break;
            case "Корзина":
                CurrentPage = ShoppingCartPage;
                ButtonColors[0] = new SolidColorBrush(Colors.Transparent);
                ButtonColors[1] = new SolidColorBrush(Color.Parse("#D2D59A"));
                break;
        }
    }
    
    /// <summary>
    /// Единственный экземпляр
    /// </summary>
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

    /// <summary>
    /// Текущая страница
    /// </summary>
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