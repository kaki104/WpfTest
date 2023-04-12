using PackUriSample.Module;
using PackUriSample.Module.ViewModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PackUriSample.ViewModels
{
    public class CakeViewModel : BindableBase
    {
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
        private ImageSource _iceCream2;
        public ImageSource IceCream2
        {
            get { return _iceCream2; }
            set { SetProperty(ref _iceCream2, value); }
        }
        public CakeViewModel()
        {
            LoadCake2Images();
            LoadCake4Image();
            LoadCake1Image();
            LoadIceCream2Image();
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
        private void LoadIceCream2Image()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(typeof(PackUriSampleModule));
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
