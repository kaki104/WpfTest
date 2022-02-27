using System.Windows;
using System.Windows.Controls;

namespace ListViewSample
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            switch (button.Tag.ToString())
            {
                case "ListView1":
                    var listView1 = new ListView1();
                    listView1.ShowDialog();
                    break;
                case "ListViewCustomView":
                    var listViewCustomView = new ListViewCustomView();
                    listViewCustomView.ShowDialog();
                    break;
                case "GroupView":
                    var listViewGroup = new ListViewGroup();
                    listViewGroup.ShowDialog();
                    break;
            }
        }
    }
}
