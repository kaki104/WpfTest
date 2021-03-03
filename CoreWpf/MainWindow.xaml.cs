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

namespace CoreWpf
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
            var rect = GetWindowRectangle();
            Result.Text = $"X:{rect.X} Y:{rect.Y} Width:{rect.Width} Height:{rect.Height} Right:{rect.Right} Bottom:{rect.Bottom}";
        }

        System.Drawing.Rectangle GetWindowRectangle()
        {
            System.Drawing.Rectangle windowRectangle = System.Windows.Forms.Screen.GetWorkingArea(
                new System.Drawing.Point((int)Left, (int)Top));
            return windowRectangle;
        }
    }
}
