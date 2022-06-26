using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterSample
{
    public class MainViewModel : ObservableObject
    {
        public IList<Person> People { get; set; }

        private bool _isEdit;
        /// <summary>
        /// 편집 중 여부
        /// </summary>
        public bool IsEdit
        {
            get { return _isEdit; }
            set { SetProperty(ref _isEdit, value); }
        }

        public MainViewModel()
        {
            People = new List<Person>
            {
                new Person{ Id = 1, Name = "kaki104", Sex = true, DepartmentCode = "01" },
                new Person{ Id = 2, Name = "kaki105", Sex = false, DepartmentCode = "02" },
                new Person{ Id = 3, Name = "kaki106", Sex = true, DepartmentCode = "03" },
                new Person{ Id = 4, Name = "kaki107", Sex = false, DepartmentCode = "02" },
                new Person{ Id = 5, Name = "kaki108", Sex = true, DepartmentCode = "01" },
            };
        }


    }
}
