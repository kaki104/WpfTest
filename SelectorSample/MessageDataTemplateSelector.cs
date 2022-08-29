using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SelectorSample
{
    /// <summary>
    /// Message DataTemplateSelector - 반드시 DataTemplateSelector를 상속 받습니다.
    /// </summary>
    public class MessageDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MyDataTemaplte { get; set; }
        public DataTemplate BotDataTemplate { get; set; }
        public DataTemplate SystemDataTemplate { get; set; }
        /// <summary>
        /// 템플릿 선택용 로직 실행 메소드 - 반드시 override합니다.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //item을 MessageModel인지 확인합니다.
            if (item is MessageModel message)
            {
                //MessageType에 따라서 DataTemplate를 각각 반환합니다.
                switch(message.MessageType)
                {
                    case "Me":
                        return MyDataTemaplte;
                    case "Bot":
                        return BotDataTemplate;
                    case "System":
                        return SystemDataTemplate;
                }
            }
            return base.SelectTemplate(item, container);
        }
    }
}
