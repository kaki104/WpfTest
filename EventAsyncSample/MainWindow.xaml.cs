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
            var datas = GetDatas(_sleepConst, ((ComboBoxItem)CategoryComboBox1.SelectedItem).Content as string ?? "0_Category_0");
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
            var datas = GetDatas(_sleepConst, CategoryListBox1.SelectedItem as string ?? "CategoryListBox1");
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
            var datas = GetDatas(_sleepConst, CategoryComboBox2.SelectedItem as string ?? "CategoryComboBox2");
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
            var datas = GetDatas(_sleepConst, CategoryListBox2.SelectedItem as string ?? "CategoryListBox2.SelectedItem");
            PersonListView.ItemsSource = datas;
            PersonListView.SelectedIndex = 0;
            Debug.WriteLine($"End {DateTime.Now}");
            BusyPopup.IsOpen = false;
        }

        private IList<string> GetDatas(int sleep, string selectedString)
        {
            Task.Delay(sleep).Wait();
            _count++;
            var words = selectedString.Split('_');
            return new List<string> 
            {
                $"{_count}_{words[1] + words[2]}_01",
                $"{_count}_{words[1] + words[2]}_02",
                $"{_count}_{words[1] + words[2]}_03",
                $"{_count}_{words[1] + words[2]}_04",
                $"{_count}_{words[1] + words[2]}_05",
                $"{_count}_{words[1] + words[2]}_06",
                $"{_count}_{words[1] + words[2]}_07",
                $"{_count}_{words[1] + words[2]}_08",
                $"{_count}_{words[1] + words[2]}_09",
                $"{_count}_{words[1] + words[2]}_10",
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
