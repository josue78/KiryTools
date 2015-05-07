using System;
using System.Windows.Data;

namespace KiryTools.Converters
{
  public  class InvertValue:IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (double)value * -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (double)value * -1;

        }
    }
}
