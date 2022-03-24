using System;
using System.Windows;

namespace CreateBuildDate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var buildDate = $"ver. {new DateTime(Builtin.CompileTime, DateTimeKind.Utc).ToString("yyyy-MM-dd-HHmm")}";
            BuildDate.Text = buildDate;
        }
    }
}
