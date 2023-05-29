namespace ShopApp.Library;

/// <summary>
/// Бонусы
/// </summary>
public class Bonuses
{
    /// <summary>
    /// Курс перевода бонусов в рубли
    /// </summary>
    private double _exchangeRate;
    
    /// <summary>
    /// Количество бонусов
    /// </summary>
    private double _value;
    
    /// <summary>
    /// Курс перевода бонусов в рубли
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public double ExchangeRate
    {
        get
        {
            return _exchangeRate;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException();
            }

            _exchangeRate = value;
        }
    }

    /// <summary>
    /// Количество бонусов
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public double Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException();
            }

            _value = value;
        }
    }
    
    /// <summary>
    /// Перевод из бонусов в рубли
    /// </summary>
    /// <returns>Значение в рублях</returns>
    public double ConvertToMoney()
    {
        _value = 0;
        return _exchangeRate * _value;
    }
    
    /// <summary>
    /// Перевод части бонусов в рубли
    /// </summary>
    /// <param name="value">Количество бонусов для перевода</param>
    /// <returns>Значение в рублях</returns>
    /// <exception cref="ArgumentException"></exception>
    public double ConvertToMoney(double value)
    {
        if (value > _value)
        {
            throw new ArgumentException();
        }

        _value -= value;

        return _exchangeRate * value;
    }

    /// <summary>
    /// Конструктор бонусов
    /// </summary>
    public Bonuses()
    {
        ExchangeRate = 1;
        Value = 0;
    }

    /// <summary>
    /// Конструктор бонусов
    /// </summary>
    /// <param name="value">Количество бонусов</param>
    public Bonuses(double value)
    {
        ExchangeRate = 1;
        Value = value;
    }

    /// <summary>
    /// Конструктор бонусов
    /// </summary>
    /// <param name="value">Количество бонусов</param>
    /// <param name="exchangeRate">Курс перевода бонусов в рубли</param>
    public Bonuses(double value, double exchangeRate)
    {
        ExchangeRate = exchangeRate;
        Value = value;
    }
}