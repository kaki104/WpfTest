using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace ToolkitSample
{
    public class MainWindowViewModel : ObservableObject
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

        private Person _selectedPerson;
        /// <summary>
        /// 선택된 사람
        /// </summary>
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetProperty(ref _selectedPerson, value); }
        }

        public MainWindowViewModel()
        {
            People = new List<Person>
            {
                new Person{ Id = 1, Name = "kaki104", Sex = true},
                new Person{ Id = 2, Name = "kaki105", Sex = false},
                new Person{ Id = 3, Name = "kaki106", Sex = true},
                new Person{ Id = 4, Name = "kaki107", Sex = false},
                new Person{ Id = 5, Name = "kaki108", Sex = true},
            };
        }
    }
}
