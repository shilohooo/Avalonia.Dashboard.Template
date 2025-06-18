using Avalonia.Dashboard.Template.Messages;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Template.Services.Ui.Impl;

/// <summary>
///     主题管理服务
/// </summary>
public class ThemeService(IMessenger messenger) : IThemeService
{
    /// <inheritdoc />
    public bool IsDarkMode { get; private set; } = true;

    /// <inheritdoc />
    public void ToggleTheme(bool isDarkMode)
    {
        IsDarkMode = isDarkMode;
        messenger.Send(new ThemeChangedMessage(IsDarkMode));

        if (Application.Current is null) return;

        Application.Current.RequestedThemeVariant = IsDarkMode ? ThemeVariant.Dark : ThemeVariant.Light;
    }
}