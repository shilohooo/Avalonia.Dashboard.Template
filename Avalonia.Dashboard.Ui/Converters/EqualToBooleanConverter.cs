using System.Diagnostics;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Dashboard.Ui.Converters;

/// <summary>
/// Compare two values and return true if they are equal, otherwise false
/// </summary>
public class EqualToBooleanConverter : IValueConverter
{
    /// <inheritdoc />
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null)
        {
            return parameter is null;
        }

        // Converter param must be a string
        if (parameter is not string strParam)
        {
            return false;
        }
        
        if (value.GetType().IsEnum)
        {
            return Enum.TryParse(value.GetType(), strParam, out var result) && value.Equals(result);
        }

        return value.Equals(parameter);
    }

    /// <inheritdoc />
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
