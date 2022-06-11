using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingSample
{
    public class MainViewModel : ObservableObject
    {
        private IList<Person> _people;
        public IList<Person> People
        {
            get { return _people; }
            set { SetProperty(ref _people, value); }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private bool _sex;
        public bool Sex
        {
            get { return _sex; }
            set { SetProperty(ref _sex, value); }
        }

        public IList<bool> Sexs { get; set; }

        public MainViewModel()
        {
            People = new List<Person>
            {
                new Person{Id = 11, Name = "kaki104", Sex = true },
                new Person{Id = 22, Name = "kaki105", Sex = false },
            };
            Sexs = new List<bool>
            {
                true,
                false
            };
            Id = 99;
            Name = "kaki1004";
            Sex = false;
        }
    }
}
