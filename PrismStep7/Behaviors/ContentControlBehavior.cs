using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Controls;

namespace PrismStep7.Behaviors
{
    /// <summary>
    /// 컨텐츠 컨트롤 비헤이비어
    /// </summary>
    public class ContentControlBehavior : Behavior<ContentControl>
    {
        protected override void OnAttached()
        {
            //AssociatedObject에 이벤트를 연결 할 필요가 있으면 여기에
            ResolveView();
        }
        protected override void OnDetaching()
        {
            //AssociatedObject에 연결했던 이벤트 해제는 여기서
        }

        public string ViewName
        {
            get => (string)GetValue(ViewNameProperty);
            set => SetValue(ViewNameProperty, value);
        }

        /// <summary>
        /// 뷰이름
        /// </summary>
        public static readonly DependencyProperty ViewNameProperty =
            DependencyProperty.Register("ViewName", typeof(string), typeof(ContentControlBehavior), new PropertyMetadata(null));


        public Type ViewType
        {
            get => (Type)GetValue(ViewTypeProperty);
            set => SetValue(ViewTypeProperty, value);
        }

        /// <summary>
        /// 뷰유형
        /// </summary>
        public static readonly DependencyProperty ViewTypeProperty =
            DependencyProperty.Register("ViewType", typeof(Type), typeof(ContentControlBehavior), new PropertyMetadata(null));

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            switch (e.Property.Name)
            {
                case nameof(ViewName):
                case nameof(ViewType):
                    ResolveView();
                    break;
            }
            base.OnPropertyChanged(e);
        }

        private void ResolveView()
        {
            //AssociatedObject 연결되지 않았으면 나감
            if (AssociatedObject == null)
            {
                return;
            }
            //ViewName이 있을 때
            if (string.IsNullOrEmpty(ViewName) == false)
            {
                Type type = Type.GetType(ViewName);
                if (type != null)
                {
                    object view = App.ContainerProvider.Resolve(type);
                    AssociatedObject.Content = view;
                }
            }
            //ViewType이 있을 때
            else if (ViewType != null)
            {
                object view = App.ContainerProvider.Resolve(ViewType);
                AssociatedObject.Content = view;
            }
            //todo : AssociatedObject.Content에 이미 연결된 View가 있을 경우 반드시 뷰를 제거하고 입력해야함
        }
    }
}
