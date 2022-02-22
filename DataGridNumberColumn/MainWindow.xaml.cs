using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace DataGridNumberColumn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<Person> _persons;

        public MainWindow()
        {
            InitializeComponent();

            _persons = new ObservableCollection<Person>
            {
                new Person{ Name = "kaki104", Age = 11, Address = "Seoul1" },
                new Person{ Name = "kaki105", Age = 12, Address = "Seoul2" },
                new Person{ Name = "kaki106", Age = 13, Address = "Seoul3" },
                new Person{ Name = "kaki107", Age = 14, Address = "Seoul4" },
                new Person{ Name = "kaki108", Age = 15, Address = "Seoul5" },
                new Person{ Name = "kaki109", Age = 16, Address = "Seoul6" },
                new Person{ Name = "kaki110", Age = 17, Address = "Seoul7" },
                new Person{ Name = "kaki111", Age = 18, Address = "Seoul8" },
                new Person{ Name = "kaki112", Age = 19, Address = "Seoul9" },
                new Person{ Name = "kaki113", Age = 20, Address = "Seoul10" },
                new Person{ Name = "kaki114", Age = 21, Address = "Seoul11" },
                new Person{ Name = "kaki115", Age = 22, Address = "Seoul12" },
                new Person{ Name = "kaki116", Age = 23, Address = "Seoul13" },
                new Person{ Name = "kaki117", Age = 24, Address = "Seoul14" },
                new Person{ Name = "kaki118", Age = 25, Address = "Seoul15" },
                new Person{ Name = "kaki119", Age = 26, Address = "Seoul16" },
                new Person{ Name = "kaki120", Age = 27, Address = "Seoul17" },
                new Person{ Name = "kaki121", Age = 28, Address = "Seoul18" },
                new Person{ Name = "kaki122", Age = 29, Address = "Seoul19" },
                new Person{ Name = "kaki123", Age = 30, Address = "Seoul20" },
                new Person{ Name = "kaki124", Age = 31, Address = "Seoul21" },
                new Person{ Name = "kaki125", Age = 32, Address = "Seoul22" },
                new Person{ Name = "kaki126", Age = 33, Address = "Seoul23" },
                new Person{ Name = "kaki127", Age = 34, Address = "Seoul24" },
                new Person{ Name = "kaki128", Age = 35, Address = "Seoul25" },
                new Person{ Name = "kaki129", Age = 36, Address = "Seoul26" },
                new Person{ Name = "kaki130", Age = 37, Address = "Seoul27" },
                new Person{ Name = "kaki131", Age = 38, Address = "Seoul28" },
                new Person{ Name = "kaki132", Age = 39, Address = "Seoul29" },
                new Person{ Name = "kaki133", Age = 40, Address = "Seoul30" },
                new Person{ Name = "kaki134", Age = 41, Address = "Seoul31" },
                new Person{ Name = "kaki135", Age = 42, Address = "Seoul32" },
                new Person{ Name = "kaki136", Age = 43, Address = "Seoul33" },
                new Person{ Name = "kaki137", Age = 44, Address = "Seoul34" },
                new Person{ Name = "kaki138", Age = 45, Address = "Seoul35" },
                new Person{ Name = "kaki139", Age = 46, Address = "Seoul36" },
                new Person{ Name = "kaki140", Age = 47, Address = "Seoul37" },
                new Person{ Name = "kaki141", Age = 48, Address = "Seoul38" },
                new Person{ Name = "kaki142", Age = 49, Address = "Seoul39" },
                new Person{ Name = "kaki143", Age = 50, Address = "Seoul40" },
                new Person{ Name = "kaki0104", Age = 111, Address = "Seoul11" },
                new Person{ Name = "kaki0105", Age = 112, Address = "Seoul12" },
                new Person{ Name = "kaki0106", Age = 113, Address = "Seoul13" },
                new Person{ Name = "kaki0107", Age = 114, Address = "Seoul14" },
                new Person{ Name = "kaki0108", Age = 115, Address = "Seoul15" },
                new Person{ Name = "kaki0109", Age = 116, Address = "Seoul16" },
                new Person{ Name = "kaki0110", Age = 117, Address = "Seoul17" },
                new Person{ Name = "kaki0111", Age = 118, Address = "Seoul18" },
                new Person{ Name = "kaki0112", Age = 119, Address = "Seoul19" },
                new Person{ Name = "kaki0113", Age = 120, Address = "Seoul110" },
                new Person{ Name = "kaki0114", Age = 121, Address = "Seoul111" },
                new Person{ Name = "kaki0115", Age = 122, Address = "Seoul112" },
                new Person{ Name = "kaki0116", Age = 123, Address = "Seoul113" },
                new Person{ Name = "kaki0117", Age = 124, Address = "Seoul114" },
                new Person{ Name = "kaki0118", Age = 125, Address = "Seoul115" },
                new Person{ Name = "kaki0119", Age = 126, Address = "Seoul116" },
                new Person{ Name = "kaki0120", Age = 127, Address = "Seoul117" },
                new Person{ Name = "kaki0121", Age = 128, Address = "Seoul118" },
                new Person{ Name = "kaki0122", Age = 129, Address = "Seoul119" },
                new Person{ Name = "kaki0123", Age = 130, Address = "Seoul120" },
                new Person{ Name = "kaki0124", Age = 131, Address = "Seoul121" },
                new Person{ Name = "kaki0125", Age = 132, Address = "Seoul122" },
                new Person{ Name = "kaki0126", Age = 133, Address = "Seoul123" },
                new Person{ Name = "kaki0127", Age = 134, Address = "Seoul124" },
                new Person{ Name = "kaki0128", Age = 135, Address = "Seoul125" },
                new Person{ Name = "kaki0129", Age = 136, Address = "Seoul126" },
                new Person{ Name = "kaki0130", Age = 137, Address = "Seoul127" },
                new Person{ Name = "kaki0131", Age = 138, Address = "Seoul128" },
                new Person{ Name = "kaki0132", Age = 139, Address = "Seoul129" },
                new Person{ Name = "kaki0133", Age = 140, Address = "Seoul130" },
                new Person{ Name = "kaki0134", Age = 141, Address = "Seoul131" },
                new Person{ Name = "kaki0135", Age = 142, Address = "Seoul132" },
                new Person{ Name = "kaki0136", Age = 143, Address = "Seoul133" },
                new Person{ Name = "kaki0137", Age = 144, Address = "Seoul134" },
                new Person{ Name = "kaki0138", Age = 145, Address = "Seoul135" },
                new Person{ Name = "kaki0139", Age = 146, Address = "Seoul136" },
                new Person{ Name = "kaki0140", Age = 147, Address = "Seoul137" },
                new Person{ Name = "kaki0141", Age = 148, Address = "Seoul138" },
                new Person{ Name = "kaki0142", Age = 149, Address = "Seoul139" },
                new Person{ Name = "kaki0143", Age = 150, Address = "Seoul140" },
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PeopleDataGrid.ItemsSource = _persons;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _persons.Add(new Person { Name = "Add1", Age = 41, Address = "Seoul99" });
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (PeopleDataGrid.SelectedItem != null)
            {
                _persons.Remove(PeopleDataGrid.SelectedItem as Person);
            }
        }
    }
}
