namespace ShopApp.Library.Products;

/// <summary>
/// Продукт
/// </summary>
public abstract class Product
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Цена
    /// </summary>
    public abstract double Price { get; }
    
    /// <summary>
    /// Конструктор продукта
    /// </summary>
    /// <param name="name">Название продукта</param>
    public Product(string name)
    {
        Name = name;
    }
}