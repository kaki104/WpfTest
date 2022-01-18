using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WpfApp1.Views;

namespace WpfApp1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
                Init();
            }
        }

        private void Init()
        {
            Hello = "Hello WPF World";
            OpenWindowCommand = new RelayCommand<string>(OnOpenWindowCommand);
        }

        private void OnOpenWindowCommand(string obj)
        {
            
            switch(obj)
            {
                case "sqlite":
                    var sqliteWindow = new SqliteWindow();
                    sqliteWindow.ShowDialog();
                    break;

            }
        }

        public string Hello { get; set; }

        public ICommand OpenWindowCommand { get; set; }
    }
}