using System;
using System.Collections.Generic;
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

namespace TemplateSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var list = new List<Person>
            {
                new Person { Id = 1, Name = "kaki104", Sex = true, Description = "Item1" },
                new Person { Id = 2, Name = "kaki105", Sex = false, Description = "Item2" },
                new Person { Id = 3, Name = "kaki106", Sex = true, Description = "Item3" },
                new Person { Id = 4, Name = "kaki107", Sex = false, Description = "Item4" },
                new Person { Id = 5, Name = "kaki108", Sex = true, Description = "Item5" },
            };
            ItemsControl.ItemsSource = list;
        }
    }
}
