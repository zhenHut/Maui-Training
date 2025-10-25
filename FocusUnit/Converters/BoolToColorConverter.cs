﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusUnit.Converters
{
    public class BoolToColorConverter : IValueConverter
    {

        public Color ValidColor { get; set; } = Colors.DarkSeaGreen;
        public Color InvalidColor { get; set; } = Colors.IndianRed;


        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is bool b && b ? ValidColor : InvalidColor;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
