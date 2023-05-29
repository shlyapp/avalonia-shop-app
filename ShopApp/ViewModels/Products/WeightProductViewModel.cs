using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ShopApp.Library.Products;

namespace ShopApp.ViewModels.Products;

public class WeightProductViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// Товар, который мы отображаем
    /// </summary>
    private WeightProduct _product;
    
    // Далее мы дублируем свойства для того, чтобы корректно отобразить на форме
    
    public string Name
    {
        get
        {
            return _product.Name;
        }
    }

    public string PathToImage { get; }

    public string Price
    {
        get
        {
            return $"{_product.Price}₽";
        }
    }
    
    public string Weight
    {
        get
        {
            return $"{_product.Weight} кг.";
        }
    }

    public string PricePerWeight
    {
        get
        {
            return $"{_product.PricePerWeight}₽ - 1 кг.";
        }
    }
    
    /// <summary>
    /// Добавление товара 
    /// </summary>
    public void AddClickButton()
    {
        Database.Database.Customer.AddProduct(_product);
        
        // Оповещаем форму о изменениях
        OnPropertyChanged(nameof(Price));
        OnPropertyChanged(nameof(Weight));
    }

    /// <summary>
    /// Удаление товара
    /// </summary>
    public void RemoveClickButton()
    {
        Database.Database.Customer.RemoveProduct(_product);
        
        // Оповещаем форму о изменениях
        OnPropertyChanged(nameof(Price));
        OnPropertyChanged(nameof(Weight));
    }

    public WeightProductViewModel(WeightProduct product, string pathToImage)
    {
        _product = product;
        PathToImage = pathToImage;
    }

    // Далее идут унаследованные методы для оповещения
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