using Avalonia.Controls.Primitives;

namespace Avalonia.Dashboard.Ui.Controls;

/// <summary>
///     Svg icon
/// </summary>
public class SvgIcon : TemplatedControl
{
    public static readonly StyledProperty<string> IconNameProperty = AvaloniaProperty.Register<SvgIcon, string>(
        nameof(IconName));

    public static readonly StyledProperty<double> IconWidthProperty = AvaloniaProperty.Register<SvgIcon, double>(
        nameof(IconWidth), 24);

    public static readonly StyledProperty<double> IconHeightProperty = AvaloniaProperty.Register<SvgIcon, double>(
        nameof(IconHeight), 24);

    public string IconName
    {
        get => GetValue(IconNameProperty);
        set => SetValue(IconNameProperty, value);
    }

    public double IconWidth
    {
        get => GetValue(IconWidthProperty);
        set => SetValue(IconWidthProperty, value);
    }

    public double IconHeight
    {
        get => GetValue(IconHeightProperty);
        set => SetValue(IconHeightProperty, value);
    }
}