using System.Collections.ObjectModel;
using ShopApp.Library;
using ShopApp.Library.Products;
using ShopApp.ViewModels;
using ShopApp.ViewModels.Products;

namespace ShopApp.Database;

public class Database
{
    public static ShopViewModel Shop { get; set; }
    public static CustomerViewModel Customer { get; set; }

    static Database()
    {

        Shop = new ShopViewModel(new Shop(new ObservableCollection<Product>()
        {
            new WeightProduct("Chicken Drumstick", 429),
            new WeightProduct("Chicken Fillet", 429),
            new WeightProduct("Chicken Wings", 429),
            new WeightProduct("Cutlets", 429),
        }));
        
        Customer = new CustomerViewModel(new Customer(1000, new Bonuses(2000, 0.5)));
    }

}