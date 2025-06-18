using System.Collections.ObjectModel;
using Avalonia.Dashboard.Template.Constants;
using Avalonia.Dashboard.Template.Messages;
using Avalonia.Dashboard.Template.Models;
using Avalonia.Dashboard.Template.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Template.ViewModels;

/// <summary>
///     主窗口 vm
/// </summary>
public partial class MainWindowViewModel : RecipientViewModelBase, IRecipient<ThemeChangedMessage>,
    IRecipient<MainWindowStateChangedMessage>, IRecipient<CurrentPageChangedMessage>
{
    private readonly IMainWindowService _mainWindowService;
    private readonly INavigationService _navigationService;
    private readonly IThemeService _themeService;

    /// <summary>
    ///     当前选中的菜单项
    /// </summary>
    [ObservableProperty] private MenuItemViewModel? _currentMenu;

    /// <summary>
    ///     当前页面对应的视图模型
    /// </summary>
    [ObservableProperty] private ViewModelBase? _currentPage;

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

    #region Constructors

    public MainWindowViewModel(IMainWindowService mainWindowService, INavigationService navigationService,
        IThemeService themeService)
    {
        _mainWindowService = mainWindowService;
        _navigationService = navigationService;
        _themeService = themeService;

        IsDarkMode = themeService.IsDarkMode;
        _navigationService.NavigateTo(typeof(HomeViewModel));
    }

    #endregion

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
    public ObservableCollection<MenuItemViewModel> Menus { get; } =
    [
        new(new MenuItemModel { Title = "主页", Icon = IconName.Home, ViewType = typeof(HomeViewModel) })
            { IsActive = true },
        new(new MenuItemModel { Title = "关于", Icon = IconName.InfoRounded, ViewType = typeof(AboutViewModel) })
    ];

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

    #region Commands

    [RelayCommand]
    private void ToggleTheme(string value)
    {
        _themeService.ToggleTheme(bool.Parse(value));
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

        _navigationService.NavigateTo(clickMenu.ViewType);
    }

    [RelayCommand]
    private void Exit()
    {
        _mainWindowService.Close();
    }

    #endregion
}