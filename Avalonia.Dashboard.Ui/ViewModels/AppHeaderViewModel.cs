using Avalonia.Dashboard.Abstractions.Services;
using Avalonia.Dashboard.Abstractions.Services.I18n;
using Avalonia.Dashboard.Abstractions.Services.Ui;
using Avalonia.Dashboard.Ui.Assets.I18n;
using Avalonia.Dashboard.Ui.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.Configuration;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     顶部控件的 view model
/// </summary>
public partial class AppHeaderViewModel : RecipientViewModelBase,
    IRecipient<ThemeChangedMessage>,
    IRecipient<MainWindowStateChangedMessage>
{
    private readonly IBrowserService _browserService;
    private readonly IConfiguration _configuration;
    private readonly ILocalizationService _localizationService;
    private readonly IMainWindowService? _mainWindowService;

    [ObservableProperty] private bool _isDarkMode = true;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(MaximizeToggleButtonIcon))]
    private bool _isMaximized;

    /// <summary>
    ///     窗口最大化切换图标名称
    /// </summary>
    public string MaximizeToggleButtonIcon => IsMaximized ? "FullscreenExitRounded" : "FullscreenRounded";

    /// <summary>
    ///     应用名称
    /// </summary>
    public string AppName => _localizationService[nameof(Resources.AppName)];

    public void Receive(MainWindowStateChangedMessage message)
    {
        IsMaximized = message.Value;
    }

    public void Receive(ThemeChangedMessage message)
    {
        IsDarkMode = message.Value;
    }

    #region Constructors

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public AppHeaderViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }

    public AppHeaderViewModel(IConfiguration configuration, IBrowserService browserService,
        IMainWindowService mainWindowService, ILocalizationService localizationService)
    {
        _configuration = configuration;
        _browserService = browserService;
        _mainWindowService = mainWindowService;
        _localizationService = localizationService;
    }

    #endregion

    #region Commands

    [RelayCommand]
    private void OpenProjectPage()
    {
        _browserService.OpenPage(_configuration["Links:Repository"]);
    }

    [RelayCommand]
    private void OpenBugReportPage()
    {
        _browserService.OpenPage(_configuration["Links:BugReport"]);
    }

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
