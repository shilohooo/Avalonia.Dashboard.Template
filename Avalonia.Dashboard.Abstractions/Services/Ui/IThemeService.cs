namespace Avalonia.Dashboard.Abstractions.Services.Ui;

/// <summary>
/// </summary>
public interface IThemeService
{
    /// <summary>
    ///     应用主题是否为深色主题
    /// </summary>
    bool IsDarkMode { get; }

    /// <summary>
    ///     切换主题
    /// </summary>
    /// <param name="isDarkMode">应用主题是否为深色主题</param>
    void ToggleTheme(bool isDarkMode);
}