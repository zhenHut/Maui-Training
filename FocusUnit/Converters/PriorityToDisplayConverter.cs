
using FocusUnit.ViewModels;
using System.Globalization;

namespace FocusUnit.Converters
{
    public class PriorityToDisplayConverter : IValueConverter
    {
        object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not Priority prio)
                return value?.ToString() ?? string.Empty;

            return prio switch
            {
                Priority.Niedrig => "🔹 Niedrig",
                Priority.Mittel => "⚡ Mittel",
                Priority.Hoch => "🔥 Hoch",
                _ => prio.ToString()
            };
        }

        object? IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
