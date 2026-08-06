using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ReorderingListBoxSample
{
    /// <summary>
    /// ListBoxItem을 Drag & Drop하여 순서를 변경할 수 있는 사용자 정의 ListBox입니다.
    /// </summary>
    /// <typeparam name="T">
    /// ListBox에 표시되는 데이터 항목의 형식입니다.
    /// Drag & Drop 데이터로 객체 자체를 전달하기 위해 참조 형식으로 제한합니다.
    /// </typeparam>
    public class DragAndDropListBox<T> : ListBox
        where T : class
    {
        // 마우스 왼쪽 버튼을 누른 최초 위치입니다.
        // 실제 Drag 동작이 시작될 만큼 마우스가 이동했는지 판단할 때 사용합니다.
        private Point _dragStartPoint;

        /// <summary>
        /// 지정한 Visual 요소의 부모를 따라 올라가면서
        /// 원하는 형식의 부모 요소를 찾습니다.
        /// </summary>
        /// <typeparam name="P">찾으려는 부모 요소의 형식</typeparam>
        /// <param name="child">검색을 시작할 자식 요소</param>
        /// <returns>
        /// 지정한 형식의 부모 요소를 찾으면 해당 객체를 반환하고,
        /// 찾지 못하면 null을 반환합니다.
        /// </returns>
        private P FindVisualParent<P>(DependencyObject child)
            where P : DependencyObject
        {
            // Visual Tree에서 현재 요소의 부모를 가져옵니다.
            DependencyObject? parentObject = VisualTreeHelper.GetParent(child);

            // 더 이상 부모가 없으면 검색을 종료합니다.
            if (parentObject is null)
            {
                return null;
            }

            // 부모가 원하는 형식이면 반환하고,
            // 그렇지 않으면 상위 부모를 재귀적으로 검색합니다.
            return parentObject is P parent
                ? parent
                : FindVisualParent<P>(parentObject);
        }

        /// <summary>
        /// Drag & Drop에 필요한 이벤트와 ListBoxItem 스타일을 설정합니다.
        /// </summary>
        public DragAndDropListBox()
        {
            // ListBox 전체에서 마우스 이동을 감지하여
            // Drag 시작 여부를 판단합니다.
            PreviewMouseMove += ListBox_PreviewMouseMove;

            // 각 ListBoxItem에 적용할 스타일을 생성합니다.
            Style style = new(typeof(ListBoxItem));

            // 각 ListBoxItem이 Drop 대상이 될 수 있도록 설정합니다.
            style.Setters.Add(
                new Setter(ListBoxItem.AllowDropProperty, true));

            // 마우스 왼쪽 버튼을 누른 위치를 저장하기 위한 이벤트입니다.
            style.Setters.Add(
                new EventSetter(
                    ListBoxItem.PreviewMouseLeftButtonDownEvent,
                    new MouseButtonEventHandler(
                        ListBoxItem_PreviewMouseLeftButtonDown)));

            // 다른 항목이 현재 ListBoxItem 위에 Drop되었을 때
            // 순서를 변경하기 위한 이벤트입니다.
            style.Setters.Add(
                new EventSetter(
                    ListBoxItem.DropEvent,
                    new DragEventHandler(ListBoxItem_Drop)));

            // 생성한 스타일을 모든 ListBoxItem에 적용합니다.
            ItemContainerStyle = style;
        }

        /// <summary>
        /// 마우스가 일정 거리 이상 이동하면 Drag & Drop을 시작합니다.
        /// </summary>
        private void ListBox_PreviewMouseMove(
            object sender,
            MouseEventArgs e)
        {
            // 현재 마우스 위치를 가져옵니다.
            Point currentPoint = e.GetPosition(null);

            // 마우스 버튼을 누른 위치와 현재 위치의 차이를 계산합니다.
            Vector difference = _dragStartPoint - currentPoint;

            // 왼쪽 버튼이 눌린 상태이며,
            // 시스템에서 정의한 최소 Drag 거리 이상 이동했는지 확인합니다.
            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(difference.X) >
                    SystemParameters.MinimumHorizontalDragDistance ||
                 Math.Abs(difference.Y) >
                    SystemParameters.MinimumVerticalDragDistance))
            {
                // 실제 클릭된 요소는 TextBlock, Border 등이 될 수 있으므로
                // Visual Tree를 탐색하여 해당 ListBoxItem을 찾습니다.
                ListBoxItem? listBoxItem =
                    FindVisualParent<ListBoxItem>(
                        (DependencyObject)e.OriginalSource);

                if (listBoxItem is not null)
                {
                    // ListBoxItem의 DataContext, 즉 실제 데이터 객체를
                    // Drag 데이터로 전달합니다.
                    _ = DragDrop.DoDragDrop(
                        listBoxItem,
                        listBoxItem.DataContext,
                        DragDropEffects.Move);
                }
            }
        }

        /// <summary>
        /// 마우스 왼쪽 버튼을 누른 위치를 저장합니다.
        /// </summary>
        private void ListBoxItem_PreviewMouseLeftButtonDown(
            object sender,
            MouseButtonEventArgs e)
        {
            _dragStartPoint = e.GetPosition(null);
        }

        /// <summary>
        /// Drag 중인 항목이 다른 ListBoxItem 위에 Drop되었을 때 호출됩니다.
        /// </summary>
        private void ListBoxItem_Drop(
            object sender,
            DragEventArgs e)
        {
            // Drop 대상이 ListBoxItem인지 확인합니다.
            if (sender is not ListBoxItem targetListBoxItem)
            {
                return;
            }

            // Drag 시작 시 전달한 원본 데이터 객체를 가져옵니다.
            T? source = e.Data.GetData(typeof(T)) as T;

            // Drop 대상 ListBoxItem의 데이터 객체를 가져옵니다.
            T? target = targetListBoxItem.DataContext as T;

            // Drag 원본 또는 Drop 대상 데이터가 없으면 처리하지 않습니다.
            if (source is null || target is null)
            {
                return;
            }

            // 현재 ListBox에서 원본 항목과 대상 항목의 인덱스를 찾습니다.
            int sourceIndex = Items.IndexOf(source);
            int targetIndex = Items.IndexOf(target);

            // 유효한 항목인지 확인합니다.
            if (sourceIndex < 0 || targetIndex < 0)
            {
                return;
            }

            // 같은 위치로 Drop한 경우에는 이동할 필요가 없습니다.
            if (sourceIndex == targetIndex)
            {
                return;
            }

            // 컬렉션에서 실제 순서를 변경합니다.
            Move(source, sourceIndex, targetIndex);
        }

        /// <summary>
        /// 데이터 컬렉션에서 항목의 위치를 변경합니다.
        /// </summary>
        /// <param name="source">이동할 원본 항목</param>
        /// <param name="sourceIndex">원본 항목의 현재 인덱스</param>
        /// <param name="targetIndex">Drop 대상 항목의 인덱스</param>
        private void Move(
            T source,
            int sourceIndex,
            int targetIndex)
        {
            // 현재 코드에서는 DataContext에 컬렉션이 설정되어 있다고 가정합니다.
            if (DataContext is not IList<T> items)
            {
                return;
            }

            if (sourceIndex < targetIndex)
            {
                // 위쪽 항목을 아래쪽으로 이동하는 경우입니다.
                //
                // 대상 항목 다음 위치에 원본 항목을 먼저 삽입합니다.
                // 삽입 이후 원본 인덱스의 기존 항목을 제거합니다.
                items.Insert(targetIndex + 1, source);
                items.RemoveAt(sourceIndex);
            }
            else
            {
                // 아래쪽 항목을 위쪽으로 이동하는 경우입니다.
                //
                // 대상 위치에 원본 항목을 삽입하면
                // 기존 원본 항목의 인덱스가 1 증가합니다.
                int removeIndex = sourceIndex + 1;

                items.Insert(targetIndex, source);

                // 컬렉션 범위를 벗어나지 않는 경우
                // 기존 위치의 원본 항목을 제거합니다.
                if (removeIndex < items.Count)
                {
                    items.RemoveAt(removeIndex);
                }
            }
        }
    }

    /// <summary>
    /// ListBox에 표시할 데이터 모델입니다.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// 화면에 표시할 항목 이름입니다.
        /// </summary>
        public string Name { get; set; }

        public Item(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    /// XAML에서 Generic 클래스는 직접 사용하기 어렵기 때문에
    /// Item 형식을 지정한 비 Generic 클래스를 제공합니다.
    /// </summary>
    public class ItemDragAndDropListBox
        : DragAndDropListBox<Item>
    {
    }

    public partial class MainWindow : Window
    {
        // ObservableCollection을 사용하므로
        // 항목 추가, 삭제, 이동 결과가 ListBox UI에 자동 반영됩니다.
        private readonly IList<Item> _items =
            new ObservableCollection<Item>();

        public MainWindow()
        {
            InitializeComponent();

            // 샘플 데이터를 생성합니다.
            _items.Add(new Item("1"));
            _items.Add(new Item("2"));
            _items.Add(new Item("3"));
            _items.Add(new Item("4"));
            _items.Add(new Item("5"));
            _items.Add(new Item("6"));

            // 사용자 정의 ListBox는 DataContext를 IList<T>로 사용하여
            // Drop 시 실제 컬렉션 순서를 변경합니다.
            listBox.DataContext = _items;
        }
    }
}