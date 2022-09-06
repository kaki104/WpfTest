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
    /// 메시지 스타일 선택기
    /// </summary>
    public class MessageStyleSelector : StyleSelector
    {
        public Style MyDataStyle { get; set; }
        public Style BotDataStyle { get; set; }
        public Style SystemDataStyle { get; set; }
        /// <summary>
        /// 스타일 선택 로직 실행 메소드
        /// </summary>
        /// <param name="item"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public override Style SelectStyle(object item, DependencyObject container)
        {
            //item을 MessageModel인지 확인합니다.
            if (item is MessageModel message)
            {
                //MessageType에 따라서 Style을 반환합니다.
                switch (message.MessageType)
                {
                    case "Me":
                        return MyDataStyle;
                    case "Bot":
                        return BotDataStyle;
                    case "System":
                        return SystemDataStyle;
                }
            }
            return base.SelectStyle(item, container);
        }
    }
}
