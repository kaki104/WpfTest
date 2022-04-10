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
    /// Interaction logic for YieldWindow.xaml
    /// </summary>
    public partial class YieldWindow : Window
    {
        public YieldWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "All files (*.*)|*.*"
            };
            var result = dialog.ShowDialog();
            if (result == false)
            {
                return;
            }
            var fileName = dialog.FileName;
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }
            var models = GetModels(fileName);
            //모델을 한번에 ItemsSource에 연결
            //listBox.ItemsSource = models;

            int count = 0;
            //total count는 구할수 없음
            foreach (var model in models)
            {
                count++;
                if (count % 1000 == 0)
                {
                    CountTextBlock.Text = count.ToString("N0");
                    await Task.Delay(1);
                }
                listBox.Items.Add(model);
                //dataGrid.Items.Add(model);
            }
            CountTextBlock.Text = count.ToString("N0");
        }

        private SampleData GetModelFromString(string item)
        {
            var columns = item.Split(",");
            var model = new SampleData();
            var propertys = model.GetType().GetProperties();
            for (int i = 0; i < propertys.Count(); i++)
            {
                var property = propertys[i];
                property.SetValue(model, columns[i], null);
            }
            return model;
        }

        private IEnumerable<SampleData> GetModels(string fileName)
        {
            bool isFirstLine = true;
            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (isFirstLine == false && line != null)
                    {
                        var model = GetModelFromString(line);
                        yield return model;
                    }
                    else
                    {
                        isFirstLine = false;
                    }
                }
                reader.Close();
            }
        }
    }
}
