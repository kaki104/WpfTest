using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CrudSample.Mvvm.Converters
{
    /// <summary>
    /// BoolToVisibilityConverter
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public Visibility TrueValue { get; set; } = Visibility.Visible;

        public Visibility FalseValue { get; set; } = Visibility.Collapsed;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                if (boolValue)
                {
                    return TrueValue;
                }
                else
                {
                    return FalseValue;
                }
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
