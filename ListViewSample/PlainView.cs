using System.Windows;
using System.Windows.Controls;

namespace ListViewSample
{
    /// <summary>
    /// ListView의 View에 넣을 수 있는 뷰스타일
    /// </summary>
    public class PlainView : ViewBase
    {
        public Style ItemContainerStyle
        {
            get { return (Style)GetValue(ItemContainerStyleProperty); }
            set { SetValue(ItemContainerStyleProperty, value); }
        }

        /// <summary>
        /// ItemsControl.ItemContainerStyle를 PlainView를 추가합니다.
        /// </summary>
        public static readonly DependencyProperty ItemContainerStyleProperty =
            ItemsControl.ItemContainerStyleProperty.AddOwner(typeof(PlainView));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        /// <summary>
        /// ItemsControl.ItemTemplateProperty를 PlainView에 추가합니다.
        /// </summary>
        public static readonly DependencyProperty ItemTemplateProperty =
            ItemsControl.ItemTemplateProperty.AddOwner(typeof(PlainView));

        public double ItemWidth
        {
            get { return (double)GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }

        /// <summary>
        /// WrapPanel.ItemWidthProperty를 PlainView에 추가합니다.
        /// </summary>
        public static readonly DependencyProperty ItemWidthProperty =
            WrapPanel.ItemWidthProperty.AddOwner(typeof(PlainView));

        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        /// <summary>
        /// WrapPanel.ItemHeightProperty를 PlainView에 추가합니다.
        /// </summary>
        public static readonly DependencyProperty ItemHeightProperty =
            WrapPanel.ItemHeightProperty.AddOwner(typeof(PlainView));

        /// <summary>
        /// 기본 스타일 키 설정
        /// </summary>
        protected override object DefaultStyleKey
        {
            get
            {
                //PlainView DefaultStyleKey
                return new ComponentResourceKey(GetType(), "PlainViewDSK");
            }
        }
    }
}
