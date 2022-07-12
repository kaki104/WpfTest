using DependencyInversionSample.Common;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace BehaviorSample
{
    public class TextBoxExBehavior : AttachableForStyleBehavior<TextBox, TextBoxExBehavior>
    {
        private readonly IDynamicResource _dr;

        public TextBoxExBehavior()
        {
            Debug.WriteLine("Create TextBoxExBehavior");
            if(App.IsInDesignMode())
            {
                return;
            }
            _dr = App.Current.Services.GetService(typeof(IDynamicResource)) as IDynamicResource;
        }

        protected override void OnAttached()
        {
            AssociatedObject.GotFocus += AssociatedObject_GotFocus;
            if (_dr == null) return;
            //OnAttached가 UI Thread에서 실행되지 않기 때문에 Dispatcher 이용해서 출력
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, 
                () => 
                {
                    var text = _dr["wrd_Hello"];
                    AssociatedObject.Text = text;
                });
        }

        private void AssociatedObject_GotFocus(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("AssociatedObject_GotFocus in TextBoxExBehavior");
        }

        protected override void OnDetaching()
        {
            AssociatedObject.GotFocus -= AssociatedObject_GotFocus;
        }
    }
}
