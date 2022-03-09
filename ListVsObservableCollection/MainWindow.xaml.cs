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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListVsObservableCollection
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //App.xaml에 IoC 기능을 구현하지 않았기에 뷰모델을 직접 인스턴스 시켜서 넣는다.
            //셈플 프로젝트이기 때문에 이렇게 사용하는 것으로 실제 프로젝트에서는 Resolve를 해서 넣는 것이 좋음
            DataContext = new MainViewModel();
        }
    }
}
