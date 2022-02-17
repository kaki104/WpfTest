using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ListViewSample
{
    /// <summary>
    /// Interaction logic for ListViewCustomView.xaml
    /// </summary>
    public partial class ListViewCustomView : Window
    {
        private List<Animal> _list;

        public ListViewCustomView()
        {
            InitializeComponent();

            _list = new List<Animal>
            {
                new Animal { IsChecked=true, Name = "Cat",  Type = "animal", ImagePath = @"Images\cat.png"},
                new Animal { IsChecked=false, Name = "Dog",  Type = "animal", ImagePath = @"Images\dog.png"},
                new Animal { IsChecked=true, Name = "Fish",  Type = "fish", ImagePath = @"Images\fish.png"},
                new Animal { IsChecked=false, Name = "Flower",  Type = "plant", ImagePath = @"Images\flower.jpg"},
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListView.ItemsSource = _list;
            //GridView 스타일을 기본으로 시작
            Default.IsChecked = true;
        }

        private void Default_Checked(object sender, RoutedEventArgs e)
        {
            var button = (RadioButton)sender;
            switch (button.Content.ToString())
            {
                case "GridView":
                    ListView.View = Resources["gridView"] as ViewBase;
                    break;
                case "TileView":
                    ListView.View = Resources["tileView"] as ViewBase;
                    break;
                case "IconView":
                    ListView.View = Resources["iconView"] as ViewBase;
                    break;
            }
        }
    }
}
