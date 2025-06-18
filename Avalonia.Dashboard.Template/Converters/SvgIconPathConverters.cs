using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using Avalonia.Data.Converters;
using Avalonia.Dashboard.Template.Constants;

namespace Avalonia.Dashboard.Template.Converters;

/// <summary>
///     Svg 图标路径转换器
/// </summary>
public class SvgIconPathConverters : IValueConverter
{
    /// <inheritdoc />
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        Debug.WriteLine($"SvgIconPathConverters.Convert - {value}, {targetType}, {parameter}, {culture}");
        var iconPath = value is not IconName icon ? null : $"/Assets/Icons/MaterialSymbols/{Enum.GetName(icon)}.svg";
        Debug.WriteLine($"SvgIconPathConverters.Convert Result - {iconPath}");
        return iconPath;
    }

    /// <inheritdoc />
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null) return null;

        var iconName = Path.GetFileNameWithoutExtension(value.ToString());
        return string.IsNullOrWhiteSpace(iconName) ? null : Enum.Parse(typeof(IconName), iconName);
    }
}