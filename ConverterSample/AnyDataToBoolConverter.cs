using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace ConverterSample
{
    /// <summary>
    /// 여러 형태 데이터와 비교해서 bool반환 parameter : None|Edited|New...등으로 사용
    /// </summary>
    public class StringCompareParameterToBoolConverter : IValueConverter
    {
        /// <summary>
        /// true일때 값
        /// </summary>
        public bool TrueValue { get; set; } = true;
        /// <summary>
        /// false일때 값
        /// </summary>
        public bool FalseValue { get; set; } = false;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool returnValue = FalseValue;
            string data = value?.ToString() ?? "";
            if (parameter is not string para)
            {
                return returnValue;
            }
            string[] split = para.Split('|');
            returnValue = split.Contains(data) ? TrueValue : FalseValue;
            return returnValue;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
