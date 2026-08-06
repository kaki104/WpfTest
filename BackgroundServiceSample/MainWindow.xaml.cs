using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace BackgroundServiceSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private long _count;
        private readonly DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();

            _timer = new DispatcherTimer(TimeSpan.FromSeconds(10),
                DispatcherPriority.Normal, TimerTick, App.Current.Dispatcher);
        }

        private async Task<DataTable> GetSampleDataTableAsync(string query)
        {
            //https://github.com/microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            DataTable returnDataTable = null;

            using (SqlConnection conn = new(connectionString))
            {
                //using(var cmd = new SqlCommand("select * from Customers", conn))
                //{
                //    var reader = await cmd.ExecuteReaderAsync();
                //}
                using SqlDataAdapter adapter = new(query, conn);
                using DataSet ds = new();
                await Task.Run(() =>
                {
                    _ = adapter.Fill(ds);
                    returnDataTable = ds.Tables[0];
                });
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
            switch (_count % 3)
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
