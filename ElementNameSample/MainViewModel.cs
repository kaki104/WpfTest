using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementNameSample
{
    public class MainViewModel : ObservableObject
    {
        public IList<Person> People { get; set; }

        public MainViewModel()
        {
            People = new List<Person>
            {
                new Person{ Id = 1, Name = "kaki104", Sex = true },
                new Person{ Id = 2, Name = "kaki105", Sex = false },
                new Person{ Id = 3, Name = "kaki106", Sex = true },
                new Person{ Id = 4, Name = "kaki107", Sex = false },
                new Person{ Id = 5, Name = "kaki108", Sex = true },
            };
        }
    }
}
