using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SourceSample
{
    public class MessageExt
    {
        public static string GetMessage(DependencyObject obj)
        {
            return (string)obj.GetValue(MessageProperty);
        }

        public static void SetMessage(DependencyObject obj, string value)
        {
            obj.SetValue(MessageProperty, value);
        }
        
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.RegisterAttached("Message", typeof(string), typeof(MessageExt), new PropertyMetadata(null));

    }
}
