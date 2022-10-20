using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Windows.Input;

namespace TelerikSample1
{
    public class MainWindowViewModel : ObservableObject
    {
        private IList<Person> _people;
        /// <summary>
        /// 피플~
        /// </summary>
        public IList<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        private string _message;
        /// <summary>
        /// 결과 출력용 메시지
        /// </summary>
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        /// <summary>
        /// 서비스 프로바이더
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        public MainWindowViewModel()
        {

        }
        public MainWindowViewModel(IServiceProvider serviceProvider) : this()
        {
            //App.Current.Services.GetService를 직접 사용하지 않고, Injection 받아서 사용합니다.
            _serviceProvider = serviceProvider;
            Init();
        }

        private void Init()
        {
            People = new ObservableCollection<Person>
            {
                new Person { Id = 1, Name = "kaki104", Sex = true, Description = "hehehe" },
                new Person { Id = 2, Name = "kaki105", Sex = false, Description = "hahaha" },
                new Person { Id = 3, Name = "kaki106", Sex = true, Description = "hohoho" },
                new Person { Id = 4, Name = "kaki107", Sex = false, Description = "kekeke" },
                new Person { Id = 5, Name = "kaki108", Sex = true, Description = "kokoko" },
            };
        }
    }
}
