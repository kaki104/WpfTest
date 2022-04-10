using Microsoft.Xaml.Behaviors;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LargeFileReadSample
{
    public class ItemsControlBehavior : Behavior<ItemsControl>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
        }

        public IEnumerable<object> EnumerableDatas
        {
            get { return (IEnumerable<object>)GetValue(EnumerableDatasProperty); }
            set { SetValue(EnumerableDatasProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnumerableDatas.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnumerableDatasProperty =
            DependencyProperty.Register(nameof(EnumerableDatas), typeof(IEnumerable<object>),
                typeof(ItemsControlBehavior), new PropertyMetadata(null, EnumerableDatasChanged));

        private static void EnumerableDatasChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = (ItemsControlBehavior)d;
            behavior.SetEnumerableDatas();
        }

        private async void SetEnumerableDatas()
        {
            AssociatedObject.Items.Clear();
            if (EnumerableDatas != null)
            {
                int count = 0;
                foreach (var model in EnumerableDatas)
                {
                    count++;
                    if (count % 2000 == 0)
                    {
                        Count = count;
                        await Task.Delay(1);
                    }
                    AssociatedObject.Items.Add(model);
                }
                Count = count;
            }
        }

        public IAsyncEnumerable<object> AsyncEnumerableDatas
        {
            get { return (IAsyncEnumerable<object>)GetValue(AsyncEnumerableDatasProperty); }
            set { SetValue(AsyncEnumerableDatasProperty, value); }
        }

        /// <summary>
        /// AsyncEnumerableDatas
        /// </summary>
        public static readonly DependencyProperty AsyncEnumerableDatasProperty =
            DependencyProperty.Register(nameof(AsyncEnumerableDatas), typeof(IAsyncEnumerable<object>), typeof(ItemsControlBehavior),
                new PropertyMetadata(null, AsyncEnumerableDatasChanged));

        private static void AsyncEnumerableDatasChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = (ItemsControlBehavior)d;
            behavior.SetAsyncEnumerableDatas();
        }

        private async void SetAsyncEnumerableDatas()
        {
            AssociatedObject.Items.Clear();
            if (AsyncEnumerableDatas != null)
            {
                int count = 0;
                await foreach (var model in AsyncEnumerableDatas)
                {
                    count++;
                    if (count % 2000 == 0)
                    {
                        Count = count;
                        await Task.Delay(1);
                    }
                    AssociatedObject.Items.Add(model);
                }
                Count = count;
            }
        }

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        /// <summary>
        /// Count
        /// </summary>
        public static readonly DependencyProperty CountProperty =
            DependencyProperty.Register(nameof(Count), typeof(int), typeof(ItemsControlBehavior), new PropertyMetadata(0));


    }
}
