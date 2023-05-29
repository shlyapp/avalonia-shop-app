using System;
using ShopApp.Library;

namespace ShopApp.ViewModels;

/// <summary>
/// Данные о покупке
/// </summary>
public class PurshareWindowViewModel
{
    /// <summary>
    /// Покупатель
    /// </summary>
    public CustomerViewModel Customer { get; }
    
    /// <summary>
    /// Сообщение о успешности покупки
    /// </summary>
    public string ResultMessage { get; }
    
    /// <summary>
    /// Информация о бонусе или о том, сколько нехватило
    /// </summary>
    public string Info { get; }
    
    public PurshareWindowViewModel(bool result, double money)
    {
        Customer = Database.Database.Customer;

        // В зависимости от того, состоялась покупка или нет, выводим нужные сообщения
        if (result)
        {
            ResultMessage = "Успешно!";
            Info = $"Добавлено бонусов: {money * Database.Database.Customer.Model.Bonuses.ExchangeRate * 0.5}";
            Database.Database.Customer.Model.Bonuses.Value +=
                money * Database.Database.Customer.Model.Bonuses.ExchangeRate * 0.5;
        }
        else
        {
            ResultMessage = "Недостачно средств";
            Info = $"Не хватает: {Math.Abs(money)}";
        }
    }
    
}