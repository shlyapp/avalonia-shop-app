using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using ShopApp.Library.Products;

namespace ShopApp.Library;

/// <summary>
/// Магазин
/// </summary>
public class Shop
{
    /// <summary>
    /// Товары
    /// </summary>
    public ObservableCollection<Product> Products { get; set; }
    
    /// <summary>
    /// Конструктор магазина
    /// </summary>
    public Shop()
    {
        Products = new ObservableCollection<Product>();
    }
    
    /// <summary>
    /// Конструктор магазина
    /// </summary>
    /// <param name="products">Товары</param>
    public Shop(ObservableCollection<Product> products)
    {
        Products = products;
    }
    
    /// <summary>
    /// Попытка покупки товара
    /// </summary>
    /// <param name="customer">Покупатель</param>
    /// <returns>true - успешно, false - неуспешно</returns>
    public bool TryBuyItems(Customer customer)
    {
        if (customer.ShoppingCart.TotalPrice <= customer.Money)
        {
            customer.Money -= customer.ShoppingCart.TotalPrice;
            customer.ShoppingCart.Clear();
            return true;
        }
        
        if (customer.ShoppingCart.TotalPrice <= (customer.Money + (customer.Bonuses.Value * customer.Bonuses.ExchangeRate)))
        {
            double needValueInBonuses = (customer.ShoppingCart.TotalPrice - customer.Money) * customer.Bonuses.ExchangeRate;
            customer.Money = 0;

            customer.Bonuses.ConvertToMoney(needValueInBonuses);
            
            customer.ShoppingCart.Clear();
            
            return true;
        }

        return false;
    }
}