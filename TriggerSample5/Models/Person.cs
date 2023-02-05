using System.Collections.Generic;

namespace TriggerSample5.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool? Sex { get; set; }

        public string Description { get; set; } = string.Empty;

        public int Age { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public IList<object> Childs { get; set; }
    }
}
