using Prism.Mvvm;

namespace CheckUrlSample.Models
{
    /// <summary>
    /// url 모델
    /// </summary>
    public class UrlModel : BindableBase
    {
        private string _url;
        /// <summary>
        /// url
        /// </summary>
        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        private bool _exist;
        /// <summary>
        /// 존재여부
        /// </summary>
        public bool Exist
        {
            get => _exist;
            set => SetProperty(ref _exist, value);
        }
    }
}
