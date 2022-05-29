using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSample.Core.Models
{
    public class Member : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime RegDate { get; set; }
        public bool IsUse { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
