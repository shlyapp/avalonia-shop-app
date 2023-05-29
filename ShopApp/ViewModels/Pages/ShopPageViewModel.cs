using System;
using System.Collections.ObjectModel;
using ShopApp.Library.Products;
using ShopApp.ViewModels.Products;

namespace ShopApp.ViewModels.Pages;

public class ShopPageViewModel : ViewModelBase
{
    public ObservableCollection<WeightProductViewModel> Products { get; set; }

    public ShopPageViewModel()
    {
        Products = Database.Database.Shop.Products;
    }
}