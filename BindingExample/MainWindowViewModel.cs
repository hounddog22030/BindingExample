using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingExample;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Fruit> _mainWindowViewModelFruits;
    private string _header;
    private FruitControlViewModel _allCarriers;

    public MainWindowViewModel()
    {
        this.MainWindowViewModelFruits = new();
        for (int i = 0; i < 10; i++)
        {
            this.MainWindowViewModelFruits.Add(new Fruit{Name = $"Fruit {i} ({this.GetType().Name })"});
            
        }
        this.Header = $"Header {this.GetType().Name}";
        this.AllCarriers = new();
        this.AllCarriers.Fruits = this.MainWindowViewModelFruits;
    }

    public ObservableCollection<Fruit> MainWindowViewModelFruits
    {
        get => _mainWindowViewModelFruits;
        set => SetField(ref _mainWindowViewModelFruits, value);
    }

    public string Header
    {
        get => _header;
        set => SetField(ref _header, value);
    }

    public FruitControlViewModel AllCarriers
    {
        get => _allCarriers;
        set
        {
            if (Equals(value, _allCarriers)) return;
            _allCarriers = value;
            OnPropertyChanged();
        }
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