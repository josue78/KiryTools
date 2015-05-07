using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace KiryTools.Converters
{
 public   class CountToVisivilityConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,CultureInfo language)
        {
            return (int) value > 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new NotImplementedException();
        }
    }
}
