using System.Collections.ObjectModel;
using System.Dynamic;
using System.Reactive.Linq;
using System.Security.Principal;
using ShopApp.Library;
using ShopApp.Library.Products;
using ShopApp.Views;
using ShopApp.Views.Pages;

namespace ShopApp.ViewModels.Pages;

public class ShoppingCartPageViewModel : ViewModelBase
{
    /// <summary>
    /// Покупатель
    /// </summary>
    public CustomerViewModel Customer { get; set; }

    /// <summary>
    /// Событие нажатия по кнопке "Купить"
    /// </summary>
    public void ClickInBuyButton()
    {
       Database.Database.Shop.BuyItems();
    }
    
    public ShoppingCartPageViewModel()
    {
        // Подтягиваем данные из базы
        Customer = Database.Database.Customer;
    }
}