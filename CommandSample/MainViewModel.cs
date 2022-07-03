using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommandSample
{
    public class MainViewModel : ObservableObject
    {
        private IList<Person> _people;
        /// <summary>
        /// People
        /// </summary>
        public IList<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }
        public IRelayCommand NormalCommand { get; set; }

        public IAsyncRelayCommand AsyncCommand { get; set; }

        public ICommand SelectionChangedCommand { get; set; }

        public ICommand AddingNewItemCommand { get; set; }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public MainViewModel()
        {
            NormalCommand = new RelayCommand(OnNormal);
            AsyncCommand = new AsyncRelayCommand(OnNormalAsync);
            SelectionChangedCommand = new RelayCommand<Person>(OnSelectionChanged);
            AddingNewItemCommand = new RelayCommand<object>(OnAddingNewItem);

            People = new List<Person>
            {
                new Person { Id = 1, Name = "kaki104", Sex = true, Description = "hehehe" },
                new Person { Id = 2, Name = "kaki105", Sex = false, Description = "hahaha" },
                new Person { Id = 3, Name = "kaki106", Sex = true, Description = "hohoho" },
                new Person { Id = 4, Name = "kaki107", Sex = false, Description = "kekeke" },
                new Person { Id = 5, Name = "kaki108", Sex = true, Description = "kokoko" },
            };
        }

        private void OnAddingNewItem(object obj)
        {
            if(obj is AddingNewItemEventArgs args)
            {
                args.NewItem = new Person { Id = People.Max(p => p.Id) + 1 };
            }
        }

        private void OnSelectionChanged(Person obj)
        {
            Message = obj == null ? "선택한 아이템이 없습니다." : $"{obj.Name}을 선택했습니다.";
        }

        private async Task OnNormalAsync()
        {
            Message = "비동기 커맨드 시작";
            await Task.Delay(3000);
            Message = "비동기 커맨드 종료";
        }

        private void OnNormal()
        {
            Message = "Normal Button을 클릭했습니다.";
        }
    }
}
