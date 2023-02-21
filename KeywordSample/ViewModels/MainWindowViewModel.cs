using Prism.Mvvm;

namespace KeywordSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _keyword;
        /// <summary>
        /// 키워드
        /// </summary>
        public string Keyword
        {
            get { return _keyword; }
            set { SetProperty(ref _keyword, value); }
        }

        private string _sampleData;
        public string SampleData
        {
            get { return _sampleData; }
            set { SetProperty(ref _sampleData, value); }
        }

        public MainWindowViewModel()
        {
        }
    }
}
