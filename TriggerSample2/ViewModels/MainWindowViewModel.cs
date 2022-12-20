using Prism.Mvvm;
using System.Collections.Generic;

namespace TriggerSample2.ViewModels
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

        public MainWindowViewModel()
        {
            var list = new List<Person>
            {
                new Person { Id = 1, Name = "kaki104", Sex = true, Description = "Item1" , X = 0, Y = 210},
                new Person { Id = 2, Name = "kaki105", Sex = false, Description = "Item2", X = 50, Y = 160},
                new Person { Id = 3, Name = "kaki106", Sex = true, Description = "Item3", X = 100, Y = 110},
                new Person { Id = 4, Name = "kaki107", Sex = false, Description = "Item4", X = 150, Y = 60},
                new Person { Id = 5, Name = "kaki108", Sex = true, Description = "Item5", X = 200, Y = 10},
            };
            People = list;
        }
    }
}
