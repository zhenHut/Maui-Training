﻿using System.Globalization;

namespace FocusUnit.Converters
{
    public class InverseBoolConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is bool boolvalue)
                return !boolvalue;
            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is bool boolValue)
                return !boolValue;
            return false;
        }
    }
}
