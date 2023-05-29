namespace ShopApp.Library;

/// <summary>
/// Покупатель
/// </summary>
public class Customer
{
    /// <summary>
    /// Количество денег
    /// </summary>
    private double _money;
    
    /// <summary>
    /// Количество бонусов
    /// </summary>
    private Bonuses _bonuses;
    
    /// <summary>
    /// Количество денег
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public double Money
    {
        get
        {
            return _money;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }

            _money = value;
        }
    }

    /// <summary>
    /// Количество бонусов
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public Bonuses Bonuses
    {
        get
        {
            return _bonuses;
        }
        set
        {
            if (value == null)
            {
                throw new ArgumentException();
            }

            _bonuses = value;
        }
    }
    
    /// <summary>
    /// Товарная корзина
    /// </summary>
    public ShoppingCart ShoppingCart { get; set; }
    
    /// <summary>
    /// Конструкор покупателя
    /// </summary>
    public Customer()
    {
        Money = 0;
        Bonuses = new Bonuses();
        ShoppingCart = new ShoppingCart();
    }
    
    /// <summary>
    /// Конструкор покупателя
    /// </summary>
    /// <param name="money">Количество денег</param>
    public Customer(double money)
    {
        Money = money;
        Bonuses = new Bonuses();
        ShoppingCart = new ShoppingCart();
    }
    
    /// <summary>
    /// Конструктор покупателя
    /// </summary>
    /// <param name="money">Количество денег</param>
    /// <param name="bonuses">Количество бонусов</param>
    public Customer(double money, Bonuses bonuses)
    {
        Money = money;
        Bonuses = bonuses;
        ShoppingCart = new ShoppingCart();
    }
    
    /// <summary>
    /// Конструктор покупателя
    /// </summary>
    /// <param name="money">Количество денег</param>
    /// <param name="bonuses">Количество бонусов</param>
    /// <param name="shoppingCart">Товарная корзина</param>
    public Customer(double money, Bonuses bonuses, ShoppingCart shoppingCart)
    {
        Money = money;
        Bonuses = bonuses;
        ShoppingCart = shoppingCart;
    }
}