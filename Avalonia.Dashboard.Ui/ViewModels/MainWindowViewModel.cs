using System.Collections.ObjectModel;
using Avalonia.Dashboard.Abstractions.Services;
using Avalonia.Dashboard.Abstractions.Services.Ui;
using Avalonia.Dashboard.Abstractions.ViewModels;
using Avalonia.Dashboard.Domains.Enums;
using Avalonia.Dashboard.Ui.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     主窗口 vm
/// </summary>
public partial class MainWindowViewModel : RecipientViewModelBase, IRecipient<ThemeChangedMessage>,
    IRecipient<MainWindowStateChangedMessage>, IRecipient<CurrentPageChangedMessage>
{
    private readonly IMainWindowService? _mainWindowService;
    private readonly IMenuService? _menuService;
    private readonly INavigationService? _navigationService;
    private readonly IThemeService? _themeService;

    /// <summary>
    ///     当前选中的菜单项
    /// </summary>
    [ObservableProperty] private MenuItemViewModel? _currentMenu;

    /// <summary>
    ///     当前页面对应的视图模型
    /// </summary>
    [ObservableProperty] private IViewModel? _currentPage;

    /// <summary>
    ///     当前主题是否为暗色主题
    /// </summary>
    [ObservableProperty] private bool _isDarkMode;

    /// <summary>
    ///     当前是否全屏
    /// </summary>
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(MainWindowPadding))]
    private bool _isMaximized;

    /// <summary>
    ///     侧边栏导航区域展开状态
    /// </summary>
    [ObservableProperty] private bool _isSidebarOpened = true;

    /// <summary>
    ///     主窗口内边距
    /// </summary>
    public Thickness MainWindowPadding => IsMaximized ? new Thickness(8) : new Thickness(0);

    /// <summary>
    ///     系统设置图标名称
    /// </summary>
    public static IconName SettingsButtonIcon => IconName.SettingsRounded;

    /// <summary>
    ///     菜单折叠图标名称
    /// </summary>
    public static IconName SidebarToggleButtonIcon => IconName.MenuRounded;

    /// <summary>
    ///     菜单列表
    /// </summary>
    public ObservableCollection<MenuItemViewModel> Menus { get; set; } = [];

    /// <inheritdoc />
    public void Receive(CurrentPageChangedMessage message)
    {
        CurrentPage = message.Value;
    }

    /// <inheritdoc />
    public void Receive(MainWindowStateChangedMessage message)
    {
        IsMaximized = message.Value;
    }

    /// <inheritdoc />
    public void Receive(ThemeChangedMessage message)
    {
        IsDarkMode = message.Value;
    }

    /// <summary>
    ///     初始化菜单数据
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

    #region Constructors

    public MainWindowViewModel()
    {
        // for design time only
    }

    public MainWindowViewModel(IMainWindowService mainWindowService, INavigationService navigationService,
        IThemeService themeService, IMenuService menuService)
    {
        _mainWindowService = mainWindowService;
        _navigationService = navigationService;
        _themeService = themeService;
        _menuService = menuService;

        IsDarkMode = _themeService.IsDarkMode;

        InitMenus();
    }

    #endregion

    #region Commands

    [RelayCommand]
    private void ToggleTheme(string value)
    {
        _themeService?.ToggleTheme(bool.Parse(value));
    }

    [RelayCommand]
    private void ToggleSidebar()
    {
        IsSidebarOpened = !IsSidebarOpened;
    }


    [RelayCommand]
    private void Navigate(MenuItemViewModel? clickMenu)
    {
        if (clickMenu is null || clickMenu.IsActive) return;

        clickMenu.IsActive = true;
        CurrentMenu = clickMenu;

        foreach (var menuItemViewModel in Menus)
        {
            if (menuItemViewModel == clickMenu) continue;

            menuItemViewModel.IsActive = false;
        }

        _navigationService?.NavigateTo(clickMenu.ViewName);
    }

    [RelayCommand]
    private void Exit()
    {
        _mainWindowService?.Close();
    }

    #endregion
}