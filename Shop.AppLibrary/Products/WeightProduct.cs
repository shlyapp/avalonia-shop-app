namespace ShopApp.Library.Products;

/// <summary>
/// Весовой товар
/// </summary>
public class WeightProduct : Product
{
    /// <summary>
    /// Цена за единицу веса
    /// </summary>
    private double _pricePerWeight;
    
    /// <summary>
    /// Вес
    /// </summary>
    private double _weight;

    public override double Price 
    {
        get
        {
            return _pricePerWeight * _weight;
        }
    }
    
    /// <summary>
    /// Цена за единицу веса
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public double PricePerWeight
    {
        get
        {
            return _pricePerWeight;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException();
            }

            _pricePerWeight = value;
        }
    }
    
    /// <summary>
    /// Вес
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public double Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException();
            }

            _weight = value;
        }
    }
    
    /// <summary>
    /// Конструктор весового товара
    /// </summary>
    /// <param name="name">Название</param>
    /// <param name="pricePerWeight">Цена за единицу веса</param>
    public WeightProduct(string name, double pricePerWeight) : base(name)
    {
        PricePerWeight = pricePerWeight;
        Weight = 1;
    }
    
    /// <summary>
    /// Конструктор весового товара
    /// </summary>
    /// <param name="name">Название</param>
    /// <param name="pricePerWeight">Цена за единицу веса</param>
    /// <param name="weight">Вес</param>
    public WeightProduct(string name, double pricePerWeight, double weight) : base(name)
    {
        PricePerWeight = pricePerWeight;
        Weight = weight;
    }
}