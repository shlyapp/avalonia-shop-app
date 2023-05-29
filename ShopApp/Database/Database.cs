using System.Collections.ObjectModel;
using ShopApp.Library;
using ShopApp.Library.Products;
using ShopApp.ViewModels;
using ShopApp.ViewModels.Products;

namespace ShopApp.Database;

/// <summary>
/// Псевдо база данных
/// </summary>
public class Database
{
    /// <summary>
    /// Магазин с товарами
    /// </summary>
    public static ShopViewModel Shop { get; set; }
    
    /// <summary>
    /// Покупатель
    /// </summary>
    public static CustomerViewModel Customer { get; set; }

    /// <summary>
    /// Статический инициализатор свойств
    /// </summary>
    static Database()
    {
        // Заполняем продукты магазина
        Shop = new ShopViewModel(new Shop(new ObservableCollection<Product>()
        {
            new WeightProduct("Chicken Drumstick", 429),
            new WeightProduct("Chicken Fillet", 429),
            new WeightProduct("Chicken Wings", 429),
            new WeightProduct("Cutlets", 429),
        }));
        
        // Инициализируем покупателя
        Customer = new CustomerViewModel(new Customer(1000, new Bonuses(2000, 0.5)));
    }

}