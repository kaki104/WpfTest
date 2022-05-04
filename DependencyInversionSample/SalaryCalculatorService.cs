using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionSample
{
    internal class SalaryCalculatorService
    {
        public float CalculateSalary(int hoursWorked, float hourlyRate)
        {
            return hoursWorked * hourlyRate;
        }
    }
}
