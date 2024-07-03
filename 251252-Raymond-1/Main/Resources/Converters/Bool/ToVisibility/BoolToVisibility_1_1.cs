﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HMI.Resources.Converters
{
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class BoolToVisibility_1_1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value)
                    return Visibility.Visible;
                else 
                    return Visibility.Collapsed;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
