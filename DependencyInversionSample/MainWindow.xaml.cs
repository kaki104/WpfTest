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

namespace DependencyInversionSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IList<Employee> Employees { get; set; }

        private SalaryCalculatorService _salaryCalculatorService;

        public MainWindow()
        {
            InitializeComponent();
            Employees = new List<Employee> 
            {
                new Employee{Name = "kaki104", HourlyRate = 1.1f, HoursWorked = 30},
                new Employee{Name = "kaki105", HourlyRate = 1.5f, HoursWorked = 30},
                new Employee{Name = "kaki106", HourlyRate = 2.1f, HoursWorked = 29},
                new Employee{Name = "kaki107", HourlyRate = 2.5f, HoursWorked = 31},
                new Employee{Name = "kaki108", HourlyRate = 3.1f, HoursWorked = 32},
            };
            EmployeeDataGrid.ItemsSource = Employees;
            _salaryCalculatorService = new SalaryCalculatorService();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var employee in Employees)
            {
                employee.Salary = _salaryCalculatorService.CalculateSalary(employee.HoursWorked, employee.HourlyRate);
            }
            EmployeeDataGrid.ItemsSource = null;
            EmployeeDataGrid.ItemsSource = Employees;
        }
    }
}
