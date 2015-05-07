﻿using System;
using System.Windows.Data;

namespace KiryTools.Converters
{
    public class InvertBoolConverter : IValueConverter
    {
   

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
