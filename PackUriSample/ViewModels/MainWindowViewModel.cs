using Prism.Mvvm;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PackUriSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        private Uri _cake1;
        /// <summary>
        /// 케이크1
        /// </summary>
        public Uri Cake1
        {
            get { return _cake1; }
            set { SetProperty(ref _cake1, value); }
        }
        private ImageSource _cake2;
        /// <summary>
        /// 케이크2
        /// </summary>
        public ImageSource Cake2
        {
            get => _cake2;
            set => SetProperty(ref _cake2, value);
        }

        private ImageSource _cake4;
        /// <summary>
        /// 케이크4
        /// </summary>
        public ImageSource Cake4
        {
            get => _cake4;
            set => SetProperty(ref _cake4, value);
        }

        public MainWindowViewModel()
        {
            LoadCake2Images();
            LoadCake4Image();
            LoadCake1Image();
        }
        /// <summary>
        /// 케이크1 이미지 로드
        /// </summary>
        private void LoadCake1Image()
        {
            Cake1 = new Uri("pack://siteoforigin:,,,/Assets/Images/cake1.jpg");
        }

        /// <summary>
        /// 케이크4 이미지 로드
        /// </summary>
        private void LoadCake4Image()
        {
            BitmapImage bi = new();
            bi.BeginInit();
            bi.UriSource = new Uri("pack://siteoforigin:,,,/Assets/Images/cake4.jpg");
            bi.EndInit();
            Cake4 = bi;
        }

        /// <summary>
        /// 케이크2 이미지 로드
        /// </summary>
        private void LoadCake2Images()
        {
            System.Reflection.Assembly assembly = GetType().Assembly;
            string imageName = $"{assembly.GetName().Name}.Assets.Images.cake2.jpg";
            using System.IO.Stream stream = assembly.GetManifestResourceStream(imageName);
            if (stream == null)
            {
                return;
            }
            BitmapImage bi = new();
            bi.BeginInit();
            bi.StreamSource = stream;
            bi.EndInit();
            Cake2 = bi;
        }
    }
}
