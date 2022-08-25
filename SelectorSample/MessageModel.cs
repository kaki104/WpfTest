using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectorSample
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string MessageType { get; set; }
        public string Message { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
