using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Principal;
using ShopApp.Library;
using ShopApp.Library.Products;
using ShopApp.ViewModels.Products;
using ShopApp.Views;

namespace ShopApp.ViewModels;

public class ShopViewModel
{
    private Shop _shop;

    public ObservableCollection<WeightProductViewModel> Products
    {
        get
        {
            ObservableCollection<WeightProductViewModel> items = new ObservableCollection<WeightProductViewModel>();
            foreach (WeightProduct weightProduct in _shop.Products)
            {
                items.Add(new WeightProductViewModel(weightProduct, $"/../../Assets/Images/{weightProduct.Name.Replace(" ", "")}.png"));
            }
            
            return items;
        }
    }

    /// <summary>
    /// Метод покупки товаров
    /// </summary>
    public void BuyItems()
    {
        // Если корзина пустая, то завершаем метод
        if (Database.Database.Customer.Model.ShoppingCart.Products.Count == 0)
        {
            return;
        }
        
        // Необходимая сумма для покупки
        double money = Database.Database.Customer.Model.ShoppingCart.TotalPrice;
        
        // Окно для вывода результата
        PurshareWindow window;
        
        if (_shop.TryBuyItems(Database.Database.Customer.Model))
        {
            window = new PurshareWindow(true, money);
        }
        else
        {
            window = new PurshareWindow(false, Database.Database.Customer.Model.ShoppingCart.TotalPrice - money - Database.Database.Customer.Model.Bonuses.Value * Database.Database.Customer.Model.Bonuses.ExchangeRate);
        }
        
        window.Show();
        MainWindowViewModel.Instanse.ChangeCurrentPage("Товары");
    }
    
    public ShopViewModel(Shop shop)
    {
        _shop = shop;
    }
}