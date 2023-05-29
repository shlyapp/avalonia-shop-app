using System;
using System.Collections.ObjectModel;
using ShopApp.Library.Products;
using ShopApp.ViewModels.Products;

namespace ShopApp.ViewModels.Pages;

public class ShopPageViewModel : ViewModelBase
{
    /// <summary>
    /// Продукты магазина
    /// </summary>
    public ObservableCollection<WeightProductViewModel> Products { get; set; }

    public ShopPageViewModel()
    {
        // Подтягиваем данные из базы
        Products = Database.Database.Shop.Products;
    }
}