using System.Diagnostics;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Avalonia.Dashboard.Ui.Converters;

/// <summary>
///     Svg图标颜色转换器
/// </summary>
public class SvgColorConverter : IValueConverter
{
    /// <inheritdoc />
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        Debug.WriteLine($"SvgColorConverter.Convert - {value}, {targetType}, {parameter}, {culture}");
        Debug.WriteLine($"SvgColorConverter.Convert Value Type - {value?.GetType()}");
        return value switch
        {
            SolidColorBrush colorBrush =>
                $"path {{ fill: #{colorBrush.Color.R:X2}{colorBrush.Color.G:X2}{colorBrush.Color.B:X2} }}",
            IImmutableSolidColorBrush colorBrush =>
                $"path {{ fill: #{colorBrush.Color.R:X2}{colorBrush.Color.G:X2}{colorBrush.Color.B:X2} }}",
            Color color => $"path {{ fill: #{color.R:X2}{color.G:X2}{color.B:X2} }}",
            string hexColor => $"path {{ fill: {hexColor} }}",
            _ => AvaloniaProperty.UnsetValue
        };
    }

    /// <inheritdoc />
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
