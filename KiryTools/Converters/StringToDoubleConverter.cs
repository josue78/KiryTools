using System;
using System.Globalization;
using System.Windows.Data;

namespace KiryTools.Converters
{
 public   class StringToDoubleConverter:IValueConverter
    {
     public object Convert(object value, Type targetType, object parameter, CultureInfo language)
     {
         return value == null ? null : value.ToString()=="0"?"":value.ToString();
        
     }

     public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
     {
         if (value == null) return 0;
         double valueDecimal;
         return double.TryParse(value.ToString(), out valueDecimal) ? valueDecimal : 0;
     }
    }
}
