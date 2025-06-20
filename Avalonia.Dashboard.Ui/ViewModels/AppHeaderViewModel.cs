using Avalonia.Dashboard.Abstractions.Services.Ui;
using Avalonia.Dashboard.Domains.Enums;
using Avalonia.Dashboard.Ui.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     顶部控件的 view model
/// </summary>
public partial class AppHeaderViewModel : RecipientViewModelBase,
    IRecipient<ThemeChangedMessage>,
    IRecipient<MainWindowStateChangedMessage>
{
    private readonly IMainWindowService? _mainWindowService;

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

    #region Constructors

    protected AppHeaderViewModel()
    {
    }

    public AppHeaderViewModel(IMainWindowService mainWindowService)
    {
        _mainWindowService = mainWindowService;
    }

    #endregion

    #region Commands

    [RelayCommand]
    private void Minimize()
    {
        _mainWindowService?.Minimize();
    }

    [RelayCommand]
    private void Maximize()
    {
        _mainWindowService?.Maximize();
    }

    [RelayCommand]
    private void Exit()
    {
        _mainWindowService?.Close();
    }

    #endregion
}