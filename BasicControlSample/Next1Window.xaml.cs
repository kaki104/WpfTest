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
using System.Windows.Shapes;

namespace BasicControlSample
{
    /// <summary>
    /// Interaction logic for Next1Window.xaml
    /// </summary>
    public partial class Next1Window : Window
    {
        public Next1Window()
        {
            InitializeComponent();

            DataContext = new Next1ViewModel();
        }
    }
}
