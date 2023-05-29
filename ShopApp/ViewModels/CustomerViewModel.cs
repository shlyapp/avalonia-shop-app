using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ShopApp.Library;
using ShopApp.Library.Products;
using ShopApp.ViewModels.Products;

namespace ShopApp.ViewModels;

public class CustomerViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// Покупатель для отображения
    /// </summary>
    private Customer _customer;

    // Далее мы дублируем свойства для того, чтобы корректно отобразить на форме
    
    public string Money
    {
        get
        {
            return $"Баланс: {_customer.Money}₽";
        }
    }

    public string Bonuses
    {
        get
        {
            return $"Бонусы: {_customer.Bonuses.Value}";
        }
    }

    public ObservableCollection<WeightProductViewModel> ShoppingCart
    {
        get
        {
            ObservableCollection<WeightProductViewModel> items = new ObservableCollection<WeightProductViewModel>();
            foreach (WeightProduct weightProduct in _customer.ShoppingCart)
            {
                items.Add(new WeightProductViewModel(weightProduct, $"/../../Assets/Images/{weightProduct.Name.Replace(" ", "")}.png"));
            }

            return items;
        }
    }

    public string TotalPrice
    {
        get
        {
            return $"Итого: {_customer.ShoppingCart.TotalPrice}₽";
        }
    }

    public Customer Model
    {
        get
        {
            return _customer;
        }
    }
    
    public void AddProduct(WeightProduct product)
    {
        _customer.ShoppingCart.Add(product);
    }

    public void RemoveProduct(WeightProduct product)
    {
        _customer.ShoppingCart.Remove(product);
        OnPropertyChanged(nameof(ShoppingCart));
    }
    
    public CustomerViewModel(Customer customer)
    {
        _customer = customer;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}