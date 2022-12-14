using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingExample;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Fruit> _fruits;
    private string _header;

    public MainWindowViewModel()
    {
        this.Fruits = new();
        for (int i = 0; i < 10; i++)
        {
            this.Fruits.Add(new Fruit{Name = $"Fruit {i} ({this.GetType().Name })"});
            
        }
        this.Header = $"Header {this.GetType().Name}";
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