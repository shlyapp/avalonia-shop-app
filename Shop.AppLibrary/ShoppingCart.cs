using System.Collections;
using System.Collections.ObjectModel;
using ShopApp.Library.Products;

namespace ShopApp.Library;

/// <summary>
/// Товарная корзина
/// </summary>
public class ShoppingCart : IEnumerable<Product>
{
    /// <summary>
    /// Покупаемые товары
    /// </summary>
    private ObservableCollection<Product> _products;
    
    /// <summary>
    /// Покупаемые товары
    /// </summary>
    public ObservableCollection<Product> Products
    {
        get
        {
            return _products;
        }
    }

    /// <summary>
    /// Суммарная стоимость товаров в корзине
    /// </summary>
    public double TotalPrice
    {
        get
        {
            return _products.Sum(p => p.Price);
        }
    }
    
    /// <summary>
    /// Добавление товара 
    /// </summary>
    /// <param name="product">Товар</param>
    public void Add(Product product)
    {
        foreach (var item in _products)
        {
            if (product.Name == item.Name)
            {
                if (product is WeightProduct weightProduct)
                {
                    weightProduct.Weight += 1;
                    return;
                }
                else if (product is PieceProduct pieceProduct)
                {
                    pieceProduct.Counter += 1;
                    return;
                }
            }
        }
        
        _products.Add(product);
    }

    /// <summary>
    /// Удаление товара
    /// </summary>
    /// <param name="product">Товар</param>
    public void Remove(Product product)
    {
        foreach (var item in _products)
        {
            if (product.Name == item.Name)
            {
                if (product is WeightProduct weightProduct)
                {
                    if (weightProduct.Weight == 1.0)
                    {
                        _products.Remove(product);
                        return;
                    }
                    
                    weightProduct.Weight -= 1;

                    return;
                }
                else if (product is PieceProduct pieceProduct)
                {
                    pieceProduct.Counter -= 1;
                    return;
                }
            }
        }
        
        _products.Remove(product);
    } 
    
    /// <summary>
    /// Очищение товаров
    /// </summary>
    public void Clear()
    {
        _products.Clear();
    } 
    
    public IEnumerator<Product> GetEnumerator()
    {
        return _products.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    /// <summary>
    /// Конструтор товарной корзины
    /// </summary>
    public ShoppingCart()
    {
        _products = new ObservableCollection<Product>();
    }
}