using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static readonly DependencyProperty FruitControlFruitsProperty = DependencyProperty.Register(nameof(FruitControlFruits), typeof(ObservableCollection<Fruit>), typeof(FruitControl), new PropertyMetadata(default(ObservableCollection<Fruit>)));

        public FruitControl()
        {
            InitializeComponent();
            //this.FruitControlFruits = new();
            //this.FruitControlFruits.Add(new Fruit(){Name = "FruitControl CodeBehind"});
        }

        public ObservableCollection<Fruit> FruitControlFruits
        {
            get => (ObservableCollection<Fruit>) GetValue(FruitControlFruitsProperty);
            set => SetValue(FruitControlFruitsProperty, value);
        }
    }

    public class Fruit
    {
        public string Name { get; set; }
    }
}
