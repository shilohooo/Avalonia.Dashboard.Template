using System.Diagnostics;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Dashboard.Ui.Converters;

/// <summary>
///     Svg 图标路径转换器
/// </summary>
public class SvgIconPathConverters : IValueConverter
{
    /// <inheritdoc />
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        Debug.WriteLine($"SvgIconPathConverters.Convert - {value}, {targetType}, {parameter}, {culture}");
        var iconPath = value is not string iconName ? null : $"/Assets/Icons/MaterialSymbols/{iconName}.svg";
        Debug.WriteLine($"SvgIconPathConverters.Convert Result - {iconPath}");
        return iconPath;
    }

    /// <inheritdoc />
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is null ? null : Path.GetFileNameWithoutExtension(value.ToString());
    }
}