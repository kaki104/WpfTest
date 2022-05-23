using Microsoft.Toolkit.Wpf.UI.XamlHost;
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
using Windows.Devices.Geolocation;

namespace WpfTest
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Geolocator geolocator = new Geolocator() { DesiredAccuracyInMeters = 5 };
            Geoposition pos = await geolocator.GetGeopositionAsync();
            string longitude = pos.Coordinate.Point.Position.Longitude.ToString();
            string latitude = pos.Coordinate.Point.Position.Latitude.ToString();
            LongBlock.Text = longitude;
            LatBlock.Text = latitude;

            //await TheMap.TrySetViewAsync(pos.Coordinate.Point, 15.0);
        }

        private void Host_ChildChanged(object sender, EventArgs e)
        {
            //WindowsXamlHost windowsXamlHost = (WindowsXamlHost)sender;

            //Windows.UI.Xaml.Controls.TextBlock textBlock =
            //    (Windows.UI.Xaml.Controls.TextBlock)windowsXamlHost.Child;

            //textBlock.Text = "❤❤❤❤😍😍😍😍";
        }
    }
}
