using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LargeFileReadSample
{
    public class MvvmViewModel : ObservableObject
    {
        public IRelayCommand OpenCommand { get; set; }

        private IAsyncEnumerable<SampleData> _asyncModels;
        public IAsyncEnumerable<SampleData> AsyncModels
        {
            get { return _asyncModels; }
            set { SetProperty(ref _asyncModels, value); }
        }

        private IEnumerable<SampleData> _sysnModels;
        public IEnumerable<SampleData> SyncModels
        {
            get { return _sysnModels; }
            set { SetProperty(ref _sysnModels, value); }
        }

        public MvvmViewModel()
        {
            OpenCommand = new RelayCommand(OnOpen);
        }

        private void OnOpen()
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

            SyncModels = GetModels(fileName);
            //Async
            //AsyncModels = GetModelsAsync(fileName);
        }

        private async IAsyncEnumerable<SampleData> GetModelsAsync(string fileName)
        {
            bool isFirstLine = true;
            using (var reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
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
    }
}
