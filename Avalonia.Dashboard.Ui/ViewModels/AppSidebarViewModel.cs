using System.Collections.ObjectModel;
using Avalonia.Dashboard.Abstractions.Services;
using Avalonia.Dashboard.Abstractions.Services.Ui;
using Avalonia.Dashboard.Domains.Enums;
using Avalonia.Dashboard.Ui.Controls;
using Avalonia.Dashboard.Ui.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     view model of <see cref="AppSidebar" />
/// </summary>
public partial class AppSidebarViewModel : RecipientViewModelBase, IRecipient<ThemeChangedMessage>
{
    private readonly IMainWindowService? _mainWindowService;
    private readonly IMenuService? _menuService;
    private readonly INavigationService? _navigationService;
    private readonly ISidebarService? _sidebarService;
    private readonly IThemeService? _themeService;

    [ObservableProperty] private bool _isDarkMode = true;

    /// <summary>
    ///     菜单列表
    /// </summary>
    public ObservableCollection<MenuItemViewModel> Menus { get; set; } = [];

    /// <summary>
    ///     Sidebar menu toggle icon
    /// </summary>
    public static IconName SidebarToggleButtonIcon => IconName.MenuRounded;

    /// <summary>
    ///     App settings icon
    /// </summary>
    public static IconName SettingsButtonIcon => IconName.SettingsRounded;

    /// <inheritdoc />
    public void Receive(ThemeChangedMessage message)
    {
        IsDarkMode = message.Value;
    }

    /// <summary>
    ///     Init menu data, then navigate to home view
    /// </summary>
    private void InitMenus()
    {
        const ViewName defaultActiveViewName = ViewName.Home;
        var menuItems = _menuService?.GetMenuItems().Select(item =>
        {
            var menuItemViewModel = new MenuItemViewModel(item)
            {
                IsActive = item.ViewName == defaultActiveViewName
            };
            return menuItemViewModel;
        }).ToList();
        Menus = new ObservableCollection<MenuItemViewModel>(menuItems ?? []);

        _navigationService?.NavigateTo(defaultActiveViewName);
    }

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

        _navigationService?.NavigateTo(clickMenu.ViewName);
    }

    [RelayCommand]
    private void ToggleTheme(string value)
    {
        _themeService?.ToggleTheme(bool.Parse(value));
    }

    [RelayCommand]
    private void Exit()
    {
        _mainWindowService?.Close();
    }

    #endregion

    #region Constructors

    public AppSidebarViewModel()
    {
    }

    public AppSidebarViewModel(ISidebarService sidebarService, IThemeService? themeService,
        IMainWindowService mainWindowService, IMenuService? menuService, INavigationService? navigationService)
    {
        _sidebarService = sidebarService;
        _themeService = themeService;
        _mainWindowService = mainWindowService;
        _menuService = menuService;
        _navigationService = navigationService;

        InitMenus();
    }

    #endregion
}