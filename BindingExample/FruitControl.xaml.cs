using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingExample
{
    /// <summary>
    /// Interaction logic for FruitControl.xaml
    /// </summary>
    public partial class FruitControl : UserControl
    {
        public static readonly DependencyProperty FruitsProperty = DependencyProperty.Register(nameof(Fruits), typeof(ObservableCollection<Fruit>), typeof(FruitControl), new PropertyMetadata(default(ObservableCollection<Fruit>)));
        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(nameof(Header), typeof(string), typeof(FruitControl), new PropertyMetadata(default(string)));

        public FruitControl()
        {
            InitializeComponent();
        }

        public ObservableCollection<Fruit> Fruits
        {
            get => (ObservableCollection<Fruit>) GetValue(FruitsProperty);
            set => SetValue(FruitsProperty, value);
        }

        public string Header
        {
            get => (string) GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }
    }

    public class Fruit
    {
        public string Name { get; set; }
    }
}
