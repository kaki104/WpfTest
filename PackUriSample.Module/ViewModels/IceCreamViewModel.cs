using Prism.Mvvm;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PackUriSample.Module.ViewModels
{
    /// <summary>
    /// 아이스크림 뷰모델
    /// </summary>
    public class IceCreamViewModel : BindableBase
    {
        private string _title;
        /// <summary>
        /// 제목
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private Uri _iceCream1;
        public Uri IceCream1
        {
            get => _iceCream1;
            set => SetProperty(ref _iceCream1, value);
        }
        private ImageSource _iceCream2;
        public ImageSource IceCream2
        {
            get => _iceCream2;
            set => SetProperty(ref _iceCream2, value);
        }
        private ImageSource _iceCream4;
        public ImageSource IceCream4
        {
            get => _iceCream4;
            set => SetProperty(ref _iceCream4, value);
        }
        /// <summary>
        /// 기본생성자
        /// </summary>
        public IceCreamViewModel()
        {
            Title = Application.Current.MainWindow.Title;
            LoadIceCream2Image();
            LoadIceCream4Image();
            LoadIceCream1Image();
        }
        private string _cake3;
        public string Cake3
        {
            get => _cake3;
            set => SetProperty(ref _cake3, value);
        }
        private string _cake2;
        public string Cake2
        {
            get => _cake2;
            set => SetProperty(ref _cake2, value);
        }

        private void LoadIceCream1Image()
        {
            IceCream1 = new Uri("pack://siteoforigin:,,,/Assets/Images/icecream1.jpg");
        }

        private void LoadIceCream4Image()
        {
            BitmapImage bi = new();
            bi.BeginInit();
            bi.UriSource = new Uri("pack://siteoforigin:,,,/Assets/Images/icecream4.jpg");
            bi.EndInit();
            IceCream4 = bi;
        }

        private void LoadIceCream2Image()
        {
            System.Reflection.Assembly assembly = GetType().Assembly;
            string imageName = $"{assembly.GetName().Name}.Assets.Images.icecream2.jpg";
            using System.IO.Stream stream = assembly.GetManifestResourceStream(imageName);
            if (stream == null)
            {
                return;
            }
            BitmapImage bi = new();
            bi.BeginInit();
            bi.StreamSource = stream;
            bi.EndInit();
            IceCream2 = bi;
        }
    }
}
