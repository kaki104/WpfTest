using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Threading;

namespace BackgroundServiceSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private long _count;
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();

            _timer = new DispatcherTimer(TimeSpan.FromSeconds(10),
                DispatcherPriority.Normal, TimerTick, App.Current.Dispatcher);
        }

        private async Task<DataTable> GetSampleDataTableAsync(string query)
        {
            //https://github.com/microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs
            var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DataTable returnDataTable = null;

            using (var conn = new SqlConnection(connectionString))
            {
                //using(var cmd = new SqlCommand("select * from Customers", conn))
                //{
                //    var reader = await cmd.ExecuteReaderAsync();
                //}
                using(var adapter = new SqlDataAdapter(query, conn))
                {
                    using(var ds = new DataSet())
                    {
                        await Task.Run(() => 
                        {
                            adapter.Fill(ds);
                            returnDataTable = ds.Tables[0];
                        });
                    }
                }
            }
            return returnDataTable;
        }
        private async void TimerTick(object sender, EventArgs e)
        {
            await ExecuteSampleAsync();
        }

        private async Task ExecuteSampleAsync()
        {
            _count++;
            DataTable dt = null;
            switch(_count % 3)
            {
                case 0:
                    dt = await GetSampleDataTableAsync("select * from Customers");
                    break;
                case 1:
                    dt = await GetSampleDataTableAsync("select * from Products");
                    break;
                case 2:
                    dt = await GetSampleDataTableAsync("select * from Employees");
                    break;
            }
            if (dt == null)
            {
                return;
            }
            CustomerDG.ItemsSource = dt.DefaultView;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ExecuteSampleAsync();
            _timer.Start();
        }
    }
}
