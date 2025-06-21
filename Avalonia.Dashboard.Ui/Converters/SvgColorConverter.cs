using System.Globalization;
using Avalonia.Data.Converters;

namespace Avalonia.Dashboard.Ui.Converters;

/// <summary>
///     Svg图标颜色转换器
/// </summary>
public class SvgColorConverter : IValueConverter
{
    /// <inheritdoc />
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is null ? null : $"path {{ fill: {value} }}";
    }

    /// <inheritdoc />
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}