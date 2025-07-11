using System.Collections.ObjectModel;
using System.Globalization;
using Avalonia.Dashboard.Abstractions.Services;
using Avalonia.Dashboard.Abstractions.Services.I18n;
using Avalonia.Dashboard.Abstractions.Services.Ui;
using Avalonia.Dashboard.Ui.Assets.I18n;
using Avalonia.Dashboard.Ui.Controls;
using Avalonia.Dashboard.Ui.Messages;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     view model of <see cref="AppSidebar" />
/// </summary>
public partial class AppSidebarViewModel : RecipientViewModelBase, IRecipient<ThemeChangedMessage>
{
    private readonly ILocalizationService _localizationService;
    private readonly IMainWindowService? _mainWindowService;
    private readonly IMenuService? _menuService;
    private readonly IMessenger _messenger;
    private readonly ISidebarService? _sidebarService;
    private readonly IThemeService? _themeService;

    [ObservableProperty] private string _currentCultureName;

    [ObservableProperty] private bool _isDarkMode = true;

    /// <summary>
    ///     菜单列表
    /// </summary>
    public ObservableCollection<MenuItemViewModel> Menus { get; set; } = [];

    /// <inheritdoc />
    public void Receive(ThemeChangedMessage message)
    {
        IsDarkMode = message.Value;
    }

    /// <summary>
    ///     Init menu data
    /// </summary>
    private void InitMenus()
    {
        var menuItems = _menuService?.GetMenuItems().Select(item => new MenuItemViewModel(item, _localizationService))
            .ToList();
        Menus = new ObservableCollection<MenuItemViewModel>(menuItems ?? []);

        // navigate to first menu
        Dispatcher.UIThread.Post(() =>
        {
            var firstMenu = Menus[0];
            firstMenu.IsActive = true;

            if (firstMenu.Children.Count == 0) return;

            _messenger.Send(new SubMenusChangedMessage(firstMenu.Children));
        });
    }

    #region Properties

    public string ExitButtonText => _localizationService[nameof(Resources.ExitButtonText)];

    public string LanguageButtonText => _localizationService[nameof(Resources.LanguageButtonText)];

    public string ThemesButtonText => _localizationService[nameof(Resources.ThemesButtonText)];

    public string LightThemeName => _localizationService[nameof(Resources.LightThemeName)];

    public string DarkThemeName => _localizationService[nameof(Resources.DarkThemeName)];

    #endregion

    #region Commands

    [RelayCommand]
    private void ToggleSidebar()
    {
        _sidebarService?.ToggleSidebar();
    }

    [RelayCommand]
    private void Navigate(MenuItemViewModel? clickMenu)
    {
        if (clickMenu is null || clickMenu.IsActive) return;

        clickMenu.IsActive = true;

        foreach (var menuItemViewModel in Menus)
        {
            if (menuItemViewModel == clickMenu) continue;

            menuItemViewModel.IsActive = false;
        }

        _messenger.Send(new SubMenusChangedMessage(clickMenu.Children));
    }

    [RelayCommand]
    private void ToggleTheme(string value)
    {
        _themeService?.ToggleTheme(bool.Parse(value));
    }

    [RelayCommand]
    private void ChangeLanguage(string language)
    {
        _localizationService.CurrentCulture = CultureInfo.GetCultureInfo(language);
        CurrentCultureName = _localizationService.CurrentCulture.Name;
    }

    [RelayCommand]
    private void Exit()
    {
        _mainWindowService?.Close();
    }

    #endregion

    #region Constructors

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public AppSidebarViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }

    public AppSidebarViewModel(ISidebarService sidebarService, IThemeService? themeService,
        IMainWindowService mainWindowService, IMenuService? menuService, ILocalizationService localizationService,
        IMessenger messenger)
    {
        _sidebarService = sidebarService;
        _themeService = themeService;
        _mainWindowService = mainWindowService;
        _menuService = menuService;
        _localizationService = localizationService;
        _messenger = messenger;

        CurrentCultureName = _localizationService.CurrentCulture.Name;

        InitMenus();
    }

    #endregion
}
