using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismStep3
{
    /// <summary>
    /// Person
    /// </summary>
    public class Person : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Sex { get; set; }
        public string Address { get; set; }
    }
}
