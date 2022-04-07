using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Shapes;

namespace LargeFileReadSample
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private SampleDataModel2? _selectedItem;

        public SecondWindow()
        {
            InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*";

            var result = dialog.ShowDialog();
            if (result == false)
            {
                return;
            }
            var fileName = dialog.FileName;
            if (fileName != null)
            {
                dataGrid.Items.Clear();
                listBox.Items.Clear();
                int count = 0;
                //데이터를 모두 로드해서 List를 만들어서 사용하기 때문에 5기가 메모리 필요
                //listBox.ItemsSource = GetLines(fileName);
                //foreach (var item in GetLines(fileName))
                //{
                //    await Task.Delay(1);
                //    listBox.Items.Add(item);
                //    count++;
                //    Debug.WriteLine(count);
                //}

                //리스트를 만들지 않기 때문에 메모리 필요없음 - listBox에 들어가서는 가상화가 되기 땜시 괜찮음
                //var lines2 = GetLines2Async(fileName);
                //await foreach (var line in lines2)
                //{
                //    //task없어도 괜찮기는 한데...움직임이 붕뜸
                //    await Task.Delay(1);
                //    listBox.Items.Add(line);
                //    count++;
                //    Debug.WriteLine(count);
                //}

                //4.3 아이템스소스로 넣으면 메모리를 차지하네?
                //listBox.ItemsSource = GetLines3(fileName);
                foreach (var item in GetLines3(fileName).Skip(1).Take(10000))
                {
                    if (count % 10 == 0)
                    {
                        await Task.Delay(1);
                    }
                    var model = GetModel(item);
                    dataGrid.Items.Add(model);
                    listBox.Items.Add(model);
                    count++;
                    Debug.WriteLine(count);
                }
                Debug.WriteLine("dd");
            }
        }

        private SampleDataModel2 GetModel(string item)
        {
            var columns = item.Split(",");
            var model = new SampleDataModel2();
            var propertys = model.GetType().GetProperties();
            for (int i = 0; i < propertys.Where(p => p.Name != "HasErrors").Count(); i++)
            {
                var property = propertys[i];
                property.SetValue(model, columns[i], null);
            }
            return model;
        }

        private IList<string> GetLines(string fileName)
        {
            IList<string> returnValues = new List<string>();
            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        returnValues.Add(line);
                    }
                }
                reader.Close();
            }
            return returnValues;
        }

        private async IAsyncEnumerable<string> GetLines2Async(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    if (line != null)
                    {
                        yield return line;
                    }
                }
                reader.Close();
            }
        }

        private IEnumerable<string> GetLines3(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        yield return line;
                    }
                }
                reader.Close();
            }
        }

        private void listBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _selectedItem = e.AddedItems.OfType<SampleDataModel2>().FirstOrDefault();
            if (_selectedItem == null)
            {
                return;
            }
            //item.Block = "KOREA";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_selectedItem == null)
            {
                return;
            }
            if (_selectedItem.HasErrors)
            {
                var errors = _selectedItem.GetErrors();
                MessageBox.Show(string.Join("\n", errors.Select(e => e.ErrorMessage)));
            }
            else
            {
                MessageBox.Show("Success");
            }
        }
    }
}
