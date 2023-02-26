using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace TriggerSample6.Converters
{
    /// <summary>
    /// 이벤트 아규먼트를 뷰모델에서 사용하려는 데이터 형태로 가공하는 컨버터
    /// </summary>
    public class EventArgsToValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //value를 EventArgs로 형변환 후 OriginalSource를 다시 FrameworkElement로 변환
            if(value is MouseButtonEventArgs args
                && args.OriginalSource is FrameworkElement element)
            {
                //컨트롤 내부 구성 요소가 여러가지 있는데 정확하게 원하는 컨트롤만 찍어서 반환해야 됩니다.
                //CheckBox가 그리드에 포함되어 있으면 CheckBox를 추가해야 합니다.
                switch(element)
                {
                    case TextBlock:
                    case DataGridCell:
                        return element.DataContext;
                }
            }
            //null리턴
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
