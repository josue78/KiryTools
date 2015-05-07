﻿using System;
using System.Windows;
using System.Windows.Data;

namespace KiryTools.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
 
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = (bool)value;
            return val ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
