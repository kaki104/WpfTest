using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace EventAsyncSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _count;
        //private const int _sleepConst = 5000;
        private const int _sleepConst = 3000;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CategoryComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CategoryComboBox1.SelectedItem == null)
            {
                return;
            }
            BusyPopup.IsOpen = true;
            var datas = GetDatas(_sleepConst);
            CategoryListBox1.ItemsSource = datas;
            CategoryListBox1.SelectedIndex = 0;
        }

        private void CategoryListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CategoryListBox1.SelectedItem == null)
            {
                return;
            }
            BusyPopup.IsOpen = true;
            var datas = GetDatas(_sleepConst);
            CategoryComboBox2.ItemsSource = datas;
            CategoryComboBox2.SelectedIndex = 0;
        }

        private void CategoryComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CategoryComboBox2.SelectedItem == null)
            {
                return;
            }
            BusyPopup.IsOpen = true;
            var datas = GetDatas(_sleepConst);
            CategoryListBox2.ItemsSource = datas;
            CategoryListBox2.SelectedIndex = 0;
        }

        private void CategoryListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CategoryListBox2.SelectedItem == null)
            { 
                return;
            }
            BusyPopup.IsOpen = true;
            var datas = GetDatas(_sleepConst);
            PersonListView.ItemsSource = datas;
            PersonListView.SelectedIndex = 0;
            Debug.WriteLine($"End {DateTime.Now}");
            BusyPopup.IsOpen = false;
        }

        private IList<string> GetDatas(int sleep)
        {
            Task.Delay(sleep).Wait();
            _count++;
            return new List<string> 
            { 
                $"{_count}_List01",
                $"{_count}_List02",
                $"{_count}_List03",
                $"{_count}_List04",
                $"{_count}_List05",
                $"{_count}_List06",
                $"{_count}_List07",
                $"{_count}_List08",
                $"{_count}_List09",
                $"{_count}_List10",
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Start {DateTime.Now}");
            BusyPopup.IsOpen = true;
            CategoryComboBox1.SelectedIndex = 0;
        }
    }
}
