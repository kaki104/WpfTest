using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionSample
{
    public class Employee
    {
        public string Name { get; set; }
        public int HoursWorked { get; set; }
        public float HourlyRate { get; set; }
        public float Salary { get; set; }
    }
}
