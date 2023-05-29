using System;
using ShopApp.Library;

namespace ShopApp.ViewModels;

public class PurshareWindowViewModel
{
    public CustomerViewModel Customer { get; }

    public string ResultMessage { get; }
    public string Info { get; }
    
    public PurshareWindowViewModel(bool result, double money)
    {
        Customer = Database.Database.Customer;

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