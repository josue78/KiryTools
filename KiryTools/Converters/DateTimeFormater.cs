using System;
using System.Globalization;
using System.Windows.Data;

namespace KiryTools.Converters
{
   public class DateTimeFormater:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            var date = (DateTime) value;
            return date.Hour>11?"PM":"AM";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new NotImplementedException();
        }
    }
}
