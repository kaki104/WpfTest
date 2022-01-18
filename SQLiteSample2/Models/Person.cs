using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = -1;

        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public bool HasMarried { get; set; }
    }
}
