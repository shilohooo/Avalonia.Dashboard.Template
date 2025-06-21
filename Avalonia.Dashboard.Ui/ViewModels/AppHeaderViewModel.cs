using Avalonia.Dashboard.Abstractions.Services.Ui;
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
    ///     窗口最大化切换图标名称
    /// </summary>
    public string MaximizeToggleButtonIcon => IsMaximized ? "FullscreenExitRounded" : "FullscreenRounded";

    public void Receive(MainWindowStateChangedMessage message)
    {
        IsMaximized = message.Value;
    }

    public void Receive(ThemeChangedMessage message)
    {
        IsDarkMode = message.Value;
    }

    #region Constructors

    public AppHeaderViewModel()
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
        _mainWindowService?.ToggleMaximize();
    }

    [RelayCommand]
    private void Exit()
    {
        _mainWindowService?.Close();
    }

    #endregion
}