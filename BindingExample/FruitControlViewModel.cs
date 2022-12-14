using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BindingExample;

public class FruitControlViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Fruit> _fruits;
    private string _header;

    public FruitControlViewModel()
    {
        // chris tacke - uncommenting these out make this one appear
        //this.FruitControlViewModelFruits = new();
        //this.FruitControlViewModelFruits.Add(new Fruit(){Name = "FruitControlViewModel"});
        //this.FruitControlViewModelHeader = this.GetType().Name;
    }

    public ObservableCollection<Fruit> Fruits
    {
        get => _fruits;
        set => SetField(ref _fruits, value);
    }

    public string Header
    {
        get => _header;
        set => SetField(ref _header, value);
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