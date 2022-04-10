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

        private void Button_Click(object sender, RoutedEventArgs e)
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
            listBox.ItemsSource = models;
            //dataGrid.ItemsSource = datas;
            Debug.WriteLine($"models count : {models.Count}");
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

        private IList<SampleData> GetModels(string fileName)
        {
            bool isFirstLine = true;
            IList<SampleData> returnValues = new List<SampleData>();
            using (var reader = new StreamReader(fileName))
            {
                //1줄씩 읽어서 처리
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (isFirstLine == false && line != null)
                    {
                        var model = GetModelFromString(line);
                        returnValues.Add(model);
                    }
                    else
                    {
                        isFirstLine = false;
                    }
                }
                reader.Close();
            }
            return returnValues;
        }
    }
}
