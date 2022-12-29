using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace TriggerSample3
{
    /// <summary>
    /// List 데이터 타입 존재 여부와 카운트 여부를 bool로 변환, null, 0이면 false, 0 크면 true
    /// </summary>
    public class ListToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is IList list && list.Count > 0 ? true : (object)false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
