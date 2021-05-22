using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfCombo
{
    public class MainWindowViewModel : ObservableObject
    {
        private IList<string> _enumStrings = new List<string>();

        public IList<string> EnumStrings
        {
            get => _enumStrings;
            set => SetProperty(ref _enumStrings, value);
        }

        public ICommand SelectionChangedCommand { get; set; }

        public MainWindowViewModel()
        {
            foreach (object item in Enum.GetValues(typeof(TestEnum)))
            {
                EnumStrings.Add(item.ToString());
            }

            SelectionChangedCommand = new RelayCommand<object>(OnSelectionChanged);
        }

        private void OnSelectionChanged(object obj)
        {
            SelectionChangedEventArgs args = obj as SelectionChangedEventArgs;
            if (args == null)
            {
                return;
            }

            object selectedItem = args.AddedItems[0];
            MessageBox.Show($"You selected is {selectedItem}");
        }
    }
}