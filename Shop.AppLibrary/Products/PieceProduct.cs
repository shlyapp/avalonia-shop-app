namespace ShopApp.Library.Products;

/// <summary>
/// Штучный товар
/// </summary>
public class PieceProduct : Product
{
    /// <summary>
    /// Цена за единицу 
    /// </summary>
    private double _pricePerPiece;
    
    /// <summary>
    /// Количество
    /// </summary>
    private int _counter;

    public override double Price
    {
        get
        {
            return _pricePerPiece * _counter;
        }
    }
    
    /// <summary>
    /// Цена за единицу
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public double PricePerPiece
    {
        get
        {
            return _pricePerPiece;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException();
            }

            _pricePerPiece = value;
        }
    }
    
    /// <summary>
    /// Количество
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public int Counter
    {
        get
        {
            return _counter;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException();
            }

            _counter = value;
        }
    }
    
    /// <summary>
    /// Конструктор штучного товара
    /// </summary>
    /// <param name="name">Название</param>
    /// <param name="pricePerPiece">Цена за единицу</param>
    public PieceProduct(string name, double pricePerPiece) : base(name)
    {
        PricePerPiece = pricePerPiece;
        Counter = 1;
    }
    
    /// <summary>
    /// Конструктор штучного товара
    /// </summary>
    /// <param name="name">Название</param>
    /// <param name="pricePerPiece">Цена за единицу</param>
    /// <param name="counter">Количество</param>
    public PieceProduct(string name, double pricePerPiece, int counter) : base(name)
    {
        PricePerPiece = pricePerPiece;
        Counter = counter;
    }
}