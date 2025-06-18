using Avalonia.Dashboard.Template.Constants;
using Avalonia.Dashboard.Template.Messages;
using Avalonia.Dashboard.Template.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Template.ViewModels;

/// <summary>
///     顶部控件的 view model
/// </summary>
public partial class AppHeaderViewModel : ViewModelBase, IRecipient<ThemeChangedMessage>,
    IRecipient<MainWindowStateChangedMessage>
{
    private readonly IMainWindowService _mainWindowService;

    [ObservableProperty] private bool _isDarkMode = true;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(MaximizeToggleButtonIcon))]
    private bool _isMaximized;

    public AppHeaderViewModel(IMainWindowService mainWindowService)
    {
        _mainWindowService = mainWindowService;
        WeakReferenceMessenger.Default.Register<ThemeChangedMessage>(this);
        WeakReferenceMessenger.Default.Register<MainWindowStateChangedMessage>(this);
    }

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
        _mainWindowService.Minimize();
    }

    [RelayCommand]
    private void Maximize()
    {
        _mainWindowService.Maximize();
    }

    [RelayCommand]
    private void Exit()
    {
        _mainWindowService.Close();
    }

    #endregion
}