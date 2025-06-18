using Avalonia.Dashboard.Template.Constants;
using Avalonia.Dashboard.Template.Messages;
using Avalonia.Dashboard.Template.Services.Ui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Template.ViewModels;

/// <summary>
///     顶部控件的 view model
/// </summary>
public partial class AppHeaderViewModel(IMainWindowService mainWindowService) : RecipientViewModelBase,
    IRecipient<ThemeChangedMessage>,
    IRecipient<MainWindowStateChangedMessage>
{
    [ObservableProperty] private bool _isDarkMode = true;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(MaximizeToggleButtonIcon))]
    private bool _isMaximized;

    /// <summary>
    ///     应用图标名称
    /// </summary>
    public static IconName AppIcon => IconName.ComputerRounded;

    /// <summary>
    ///     窗口最小化按钮图标名称
    /// </summary>
    public static IconName MinimizeButtonIcon => IconName.HorizontalRuleRounded;

    /// <summary>
    ///     窗口最大化切换图标名称
    /// </summary>
    public IconName MaximizeToggleButtonIcon =>
        IsMaximized ? IconName.FullscreenExitRounded : IconName.FullscreenRounded;

    /// <summary>
    ///     退出按钮图标名称
    /// </summary>
    public static IconName ExitButtonIcon => IconName.CloseRounded;

    public void Receive(MainWindowStateChangedMessage message)
    {
        IsMaximized = message.Value;
    }

    public void Receive(ThemeChangedMessage message)
    {
        IsDarkMode = message.Value;
    }

    #region Commands

    [RelayCommand]
    private void Minimize()
    {
        mainWindowService.Minimize();
    }

    [RelayCommand]
    private void Maximize()
    {
        mainWindowService.Maximize();
    }

    [RelayCommand]
    private void Exit()
    {
        mainWindowService.Close();
    }

    #endregion
}