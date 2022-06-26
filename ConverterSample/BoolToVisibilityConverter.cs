using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ConverterSample
{
    /// <summary>
    /// Bool To Visibility
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// true일때 값
        /// </summary>
        public Visibility TrueVisibility { get; set; } = Visibility.Visible;

        /// <summary>
        /// false일때 값
        /// </summary>
        public Visibility FalseVisibility { get; set; } = Visibility.Collapsed;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? TrueVisibility : FalseVisibility;
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
