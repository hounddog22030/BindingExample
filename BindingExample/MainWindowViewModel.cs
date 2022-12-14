using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BindingExample;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Fruit> _mainWindowViewModelFruits;

    public MainWindowViewModel()
    {
        this.MainWindowViewModelFruits = new();
        this.MainWindowViewModelFruits.Add(new Fruit(){Name = this.GetType().Name });
    }

    public ObservableCollection<Fruit> MainWindowViewModelFruits
    {
        get => _mainWindowViewModelFruits;
        set => SetField(ref _mainWindowViewModelFruits, value);
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