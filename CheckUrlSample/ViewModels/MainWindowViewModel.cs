using Prism.Mvvm;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Prism.Ioc;
using System.Collections;
using CheckUrlSample.Models;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Commands;
using System.Linq;

namespace CheckUrlSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private HttpClient _httpClient;
        private IContainerProvider _containerProvider;
        private string _title = "Check Url Sample";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private IList<UrlModel> _urls;
        /// <summary>
        /// Urls
        /// </summary>
        public IList<UrlModel> Urls
        {
            get { return _urls; }
            set { SetProperty(ref _urls, value); }
        }
        /// <summary>
        /// 확인 시작 커맨드
        /// </summary>
        public ICommand CheckCommand { get; set; }

        public MainWindowViewModel(IContainerProvider containerProvider)
        {
            _containerProvider = containerProvider;
            _httpClient = new HttpClient();

            CheckCommand = new DelegateCommand(OnCheck);

            Urls = new List<UrlModel>
            {
                new UrlModel{ Url = "https://img1.daumcdn.net/thumb/S96x60ht.u/?fname=https%3A%2F%2Ft1.daumcdn.net%2Fnews%2F202305%2F19%2Fchosunbiz%2F20230519060200835hnhs.jpg&amp;scode=media", Exist = false},
                new UrlModel{ Url = "https://img1.daumcdn.net/thumb/S96x60ht.u/?fname=https%3A%2F%2Ft1.daumcdn.net%2Fnews%2F202305%2F19%2Fdaejonilbo%2F20230519084619212deap.jpg&amp;scode=media", Exist = false},
                new UrlModel{ Url = "https://img1.daumcdn.net/thumb/S96x60ht.u/?fname=https%3A%2F%2Ft1.daumcdn.net%2Fnews%2F202305%2F19%2Fohmynews%2F20230519051504385stmu.jpg&amp;scode=media", Exist = false},
                new UrlModel{ Url = "https://img1.daumcdn.net/thumb/S96x60ht.u/?fname=https%3A%2F%2Ft1.daumcdn.net%2Fnews%2F202305%2F19%2Fmbn%2F20230519085338010wmzr.jpg&amp;scode=media", Exist = false},
                new UrlModel{ Url = "https://img1.daumcdn.net/thumb/S96x60ht.u/?fname=https%3A%2F%2Ft1.daumcdn.net%2Fnews%2F202305%2F19%2Fkookje%2F20230519085244687vtvo.jpg&amp;scode=media", Exist = false},
                new UrlModel{ Url = "https://img1.daumcdn.net/thumb/S96x60ht.u/?fname=https%3A%2F%2Ft1.daumcdn.net%2Fnews%2F202305%2F19%2Fjoongang%2F20230519050141577xbvp.jpg&amp;scode=media", Exist = false},
                new UrlModel{ Url = "https://img1.daumcdn.net/thumb/S96x60ht.u/?fname=https%3A%2F%2Ft1.daumcdn.net%2Fnews%2F202305%2F19%2Fmk%2F20230519085101509vynh.jpg&amp;scode=media", Exist = false},
                new UrlModel{ Url = "https://img1.daumcdn.net/thumb/S96x60ht.u/?fname=https%3A%2F%2Ft1.daumcdn.net%2Fnews%2F202305%2F19%2Fkukinews%2F20230519084703188cynf.jpg&amp;scode=media", Exist = false},
                new UrlModel{ Url = "https://img1.daumcdn.net/thumb/S96x60ht.u/?fname=https%3A%2F%2Ft1.daumcdn.net%2Fnews%2F202305%2F19%2Fjibs%2F20230519084833012igty.jpg&amp;scode=media", Exist = false},
                new UrlModel{ Url = "https://img1.daumcdn.net/thumb/S96x60ht.u/?fname=https%3A%2F%2Ft1.daumcdn.net%2Fnews%2F202305%2F19%2Fned%2F20230519084017377uwyu.jpg&amp;scode=media", Exist = false},
                new UrlModel{ Url = "https://img1.daumcdn.net/thumb/S96x60ht.u/?fname=https%3A%2F%2Ft1.daumcdn.net%2Fnews%2F202305%2F19%2Fned%2F20230519084017377uwyu.j&amp;scode=media", Exist = false},
            };
        }
        /// <summary>
        /// 존재여부 확인
        /// </summary>
        private async void OnCheck()
        {
            //CheckUrlExistAsync를 호출하는 다량의 Task 생성
            var tasks = Urls.Select(u => CheckUrlExistAsync(u.Url)).ToList();
            //모든 Task가 완료 될 때까지 await, _httpClient 1개는 한번에 4-5개의 SendAsync를 처리 합니다.
            var resuls = await Task.WhenAll(tasks);
            //모든 Task가 완료되면, 결과를 입력
            for (int i = 0; i < resuls.Count(); i++)
            {
                Urls[i].Exist = resuls[i];
            }
        }

        /// <summary>
        /// Url 존재 여부 확인
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<bool> CheckUrlExistAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException($"url is required");
            }
            try
            {
                //자동 dispose를 위해서 using 사용, head 값만 반환하는 요청 생성
                using HttpRequestMessage request = new(HttpMethod.Head, url);
                //httpclient는 1개만 만들어서 계속 사용하는 것이 권장됨
                using HttpResponseMessage response = await _httpClient.SendAsync(request);
                return response.EnsureSuccessStatusCode().IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
