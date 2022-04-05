using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace LargeFileReadSample
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
                    if(count % 10 == 0)
                    {
                        await Task.Delay(1);
                    }
                    var model = GetModel(item);
                    //listBox.Items.Add(model);
                    dataGrid.Items.Add(model);
                    count++;
                    Debug.WriteLine(count);
                }
                Debug.WriteLine("dd");
            }
        }

        private SampleDataModel GetModel(string item)
        {
            var columns = item.Split(",");
            var model = new SampleDataModel();
            var propertys = model.GetType().GetProperties();
            for (int i = 0; i < propertys.Length; i++)
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
            
        }
    }
}
