﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HMI.Resources.Converters
{
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class BoolToIsEnabled_1_0 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value)
                    return false;
                else 
                    return true;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
