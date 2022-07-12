using DependencyInversionSample.Common;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BehaviorSample
{
    public class TextBoxBehavior : Behavior<TextBox>
    {
        /// <summary>
        /// SelectAll 사용 여부 기본은 true
        /// </summary>
        public bool IsSelectAll { get; set; } = true;

        protected override void OnAttached()
        {
            //AssoicatedObject의 이벤트 핸들러 추가 - 삭제는 반드시 쌍으로 처리합니다.
            if (IsSelectAll)
            {
                AssociatedObject.GotFocus += AssociatedObject_GotFocus;
            }
            AssociatedObject.KeyDown += AssociatedObject_KeyDown;
        }

        private void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
        {
            //Enter Key입력시 EnterCommand 실행 이벤트 아규먼트 넘기는 것은 옵션
            if (e.Key == Key.Enter && EnterCommand != null)
            {
                EnterCommand.Execute(e);
                e.Handled = true;
            }
        }

        private void AssociatedObject_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            //Dispatcher를 이용해야 기능이 정상 동작합니다.
            Dispatcher.BeginInvoke(
                () =>
                {
                    AssociatedObject.SelectAll();
                }, null);
        }

        protected override void OnDetaching()
        {
            if (IsSelectAll)
            {
                AssociatedObject.GotFocus -= AssociatedObject_GotFocus;
            }
            AssociatedObject.KeyDown -= AssociatedObject_KeyDown;
        }

        public ICommand EnterCommand
        {
            get { return (ICommand)GetValue(EnterCommandProperty); }
            set { SetValue(EnterCommandProperty, value); }
        }

        /// <summary>
        /// EnterCommand
        /// </summary>
        public static readonly DependencyProperty EnterCommandProperty =
            DependencyProperty.Register(nameof(EnterCommand), typeof(ICommand), 
                typeof(TextBoxBehavior), new PropertyMetadata(null));
    }

    //public class TextBoxBehavior : Behavior<TextBox>
    //{
    //    /// <summary>
    //    /// 리소스 DI
    //    /// </summary>
    //    private IDynamicResource _dr;
    //    /// <summary>
    //    /// SelectAll 사용 여부 기본은 true
    //    /// </summary>
    //    public bool IsSelectAll { get; set; } = true;

    //    protected override void OnAttached()
    //    {
    //        //AssoicatedObject의 이벤트 핸들러 추가 - 삭제는 반드시 쌍으로 처리합니다.
    //        if(IsSelectAll)
    //        {
    //            AssociatedObject.GotFocus += AssociatedObject_GotFocus;
    //        }
    //        AssociatedObject.KeyDown += AssociatedObject_KeyDown;
    //        if (App.IsInDesignMode())
    //        {
    //            return;
    //        }

    //        _dr = App.Current.Services.GetService(typeof(IDynamicResource)) as IDynamicResource;
    //        if (_dr == null) return;
    //        AssociatedObject.Text = _dr["wrd_Hello"];
    //    }

    //    private void AssociatedObject_KeyDown(object sender, KeyEventArgs e)
    //    {
    //        //Enter Key입력시 EnterCommand 실행 이벤트 아규먼트 넘기는 것은 옵션
    //        if(e.Key == Key.Enter && EnterCommand != null)
    //        {
    //            EnterCommand.Execute(e);
    //            e.Handled = true;
    //        }
    //    }

    //    private void AssociatedObject_GotFocus(object sender, System.Windows.RoutedEventArgs e)
    //    {
    //        //Dispatcher를 이용해야 기능이 정상 동작합니다.
    //        Dispatcher.BeginInvoke(
    //            () => 
    //            {
    //                AssociatedObject.SelectAll();
    //            }, null);
    //    }

    //    protected override void OnDetaching()
    //    {
    //        if (IsSelectAll)
    //        {
    //            AssociatedObject.GotFocus -= AssociatedObject_GotFocus;
    //        }
    //        AssociatedObject.KeyDown -= AssociatedObject_KeyDown;
    //    }

    //    public ICommand EnterCommand
    //    {
    //        get { return (ICommand)GetValue(EnterCommandProperty); }
    //        set { SetValue(EnterCommandProperty, value); }
    //    }

    //    /// <summary>
    //    /// EnterCommand
    //    /// </summary>
    //    public static readonly DependencyProperty EnterCommandProperty =
    //        DependencyProperty.Register(nameof(EnterCommand), typeof(ICommand), typeof(TextBoxBehavior), new PropertyMetadata(null));
    //}
}
