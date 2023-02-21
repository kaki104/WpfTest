using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TriggerSample5.Models;

namespace TriggerSample5.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private IList<Person> _people;
        /// <summary>
        /// 사람들
        /// </summary>
        public IList<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        private Person _selectedPerson;
        /// <summary>
        /// 리스트박스에서 선택된 사람
        /// </summary>
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetProperty(ref _selectedPerson, value); }
        }
        public ICommand SelectionChangedCommand { get; set; }
        /// <summary>
        /// 첫번째 아이템 삭제 커맨드
        /// </summary>
        public ICommand RemoveCommand { get; set; }
        public MainWindowViewModel()
        {
            var childs = new List<object>
            {
                new Person { Id = 10, Name = "kaki104_C1", Sex = true, Description = "Item1" , X = 0, Y = 210, Age = 1},
                new Person { Id = 11, Name = "kaki104_C2", Sex = true, Description = "Item1" , X = 0, Y = 210, Age = 1},
            };

            var list = new ObservableCollection<Person>
            {
                new Person { Id = 1, Name = "kaki104", Sex = true, Description = "Item1" , X = 0, Y = 210, Age = 10, Childs = childs},
                new Person { Id = 2, Name = "kaki105", Sex = false, Description = "Item2", X = 50, Y = 160, Age = 20},
                new Person { Id = 3, Name = "kaki106", Sex = true, Description = "Item3", X = 100, Y = 110, Age = 30},
                new Person { Id = 4, Name = "kaki107", Sex = false, Description = "Item4", X = 150, Y = 60, Age = 40},
                new Person { Id = 5, Name = "kaki108", Sex = true, Description = "Item5", X = 200, Y = 10, Age = 50},
            };
            People = list;

            SelectionChangedCommand = new DelegateCommand<object>(OnSelectionChanged);
            RemoveCommand = new DelegateCommand(OnRemove);

        }
        private void OnRemove()
        {
            if (People.Count > 0)
            {
                People.RemoveAt(0);
            }
        }

        private void OnSelectionChanged(object parameter)
        {
        }
    }
}
