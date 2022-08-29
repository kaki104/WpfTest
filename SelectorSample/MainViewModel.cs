using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectorSample
{
    public class MainViewModel : ObservableObject
    {
        private IList<MessageModel> _messages = new ObservableCollection<MessageModel>();
        /// <summary>
        /// 메시지 목록
        /// </summary>
        public IList<MessageModel> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>
            {
                new MessageModel{ Id = 1, MessageType = "System", Message = "Start message" },
                new MessageModel{ Id = 2, MessageType = "Me", Message = "Hello", CreateAt = DateTime.Now.AddMinutes(1) },
                new MessageModel{ Id = 3, MessageType = "Bot", Message = "How can I help you?", CreateAt = DateTime.Now.AddMinutes(1) },
                new MessageModel{ Id = 4, MessageType = "Me", Message = "Sing a song", CreateAt = DateTime.Now.AddMinutes(1) },
                new MessageModel{ Id = 5, MessageType = "System", Message = "Please wait for a moment" , CreateAt = DateTime.Now.AddMinutes(60)},
                new MessageModel{ Id = 6, MessageType = "Bot", Message = "I can't sing" , CreateAt = DateTime.Now.AddMinutes(60)},
                new MessageModel{ Id = 7, MessageType = "Me", Message = "Quit" , CreateAt = DateTime.Now.AddMinutes(1)},
                new MessageModel{ Id = 8, MessageType = "System", Message = "End message" , CreateAt = DateTime.Now.AddMinutes(1)},
            };
        }
    }
}
