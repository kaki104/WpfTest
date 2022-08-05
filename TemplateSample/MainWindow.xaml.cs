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
                new Person { Id = 1, Name = "kaki104", Sex = true, Description = "Item1" , X = 0, Y = 210},
                new Person { Id = 2, Name = "kaki105", Sex = false, Description = "Item2", X = 50, Y = 160},
                new Person { Id = 3, Name = "kaki106", Sex = true, Description = "Item3", X = 100, Y = 110},
                new Person { Id = 4, Name = "kaki107", Sex = false, Description = "Item4", X = 150, Y = 60},
                new Person { Id = 5, Name = "kaki108", Sex = true, Description = "Item5", X = 200, Y = 10},
            };

            ItemsControl0.ItemsSource = list;
            ItemsControl1.ItemsSource = list;
            ItemsControl2.ItemsSource = list;
            ItemsControl3.ItemsSource = list;
            PersonContentControl.Content = list.FirstOrDefault();
        }
    }
}
