using System.Diagnostics;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Dashboard.Ui.Converters;

/// <summary>
///     Svg图标颜色转换器
/// </summary>
public class SvgColorConverter : IValueConverter
{
    private const string Black = "path { fill: #000000 }";
    private const string White = "path { fill: #ffffff }";

    /// <inheritdoc />
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        Debug.WriteLine($"SvgColorConverter.value - {value}");
        if (value is not bool isDarkMode) return Black;

        return isDarkMode ? White : Black;
    }

    /// <inheritdoc />
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}