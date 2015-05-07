using System;
using System.Globalization;
using System.Windows.Data;

namespace KiryTools.Converters
{
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter.ToString().Contains("{"))
            {
                var returnValue = value == null ? null : string.Format( CultureInfo.InvariantCulture,parameter.ToString(), value);
                return returnValue;
            }
            else
            {
                var returnValue = value == null ? null : ((DateTime)value).ToString(parameter.ToString());
                return returnValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
