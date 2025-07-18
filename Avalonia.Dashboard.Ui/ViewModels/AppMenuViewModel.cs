using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Avalonia.Dashboard.Abstractions.Services.I18n;
using Avalonia.Dashboard.Abstractions.Services.Ui;
using Avalonia.Dashboard.Ui.Assets.I18n;
using Avalonia.Dashboard.Ui.Messages;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     view model of <see cref="Avalonia.Dashboard.Ui.Controls.AppMenu" />
/// </summary>
public partial class AppMenuViewModel : RecipientViewModelBase, IRecipient<SubMenusChangedMessage>
{
    private readonly ILocalizationService _localizationService;
    private readonly INavigationService _navigationService;
    private readonly Subject<string> _searchValChanged = new();

    #region Observable Properties

    [ObservableProperty] private string? _searchVal;

    #endregion

    /// <summary>
    ///     Menu search placeholder
    /// </summary>
    public string MenuSearchPlaceholder => _localizationService[nameof(Resources.MenuSearchPlaceholder)];

    /// <summary>
    ///     Sub menus filter source
    /// </summary>
    public ObservableCollection<MenuItemViewModel> MenuSources { get; set; } = [];

    /// <summary>
    ///     Sub menus
    /// </summary>
    public ObservableCollection<MenuItemViewModel> Menus { get; set; } = [];

    /// <summary>
    ///     Sub menus changed callback
    /// </summary>
    /// <param name="message">message</param>
    public void Receive(SubMenusChangedMessage message)
    {
        if (message.Value.Count == 0)
        {
            MenuSources = [];
            Menus = [];
            return;
        }

        MenuSources.Clear();
        var menuToNavigate = message.Value.FirstOrDefault(item => item.IsActive, message.Value[0]);
        foreach (var menuItemViewModel in message.Value)
        {
            menuItemViewModel.IsActive =
                menuItemViewModel.Title.Equals(menuToNavigate.Title, StringComparison.CurrentCulture);
            MenuSources.Add(menuItemViewModel);
        }

        Menus.Clear();
        foreach (var menuSource in MenuSources) Menus.Add(menuSource);

        // navigate to first sub menu
        _navigationService.NavigateTo(menuToNavigate.ViewName);
    }

    private void OnSearch(string newVal)
    {
        Debug.WriteLine($"search val changed: {newVal}");
        var filteredMenus = string.IsNullOrWhiteSpace(newVal)
            ? MenuSources
            : MenuSources.Where(menu => menu.Title.Contains(newVal, StringComparison.OrdinalIgnoreCase));

        Dispatcher.UIThread.Post(() =>
        {
            Menus.Clear();
            foreach (var menu in filteredMenus) Menus.Add(menu);
        });
    }

    #region Partial Methods

    partial void OnSearchValChanged(string? value)
    {
        _searchValChanged.OnNext(value ?? string.Empty);
    }

    #endregion

    #region Commands

    [RelayCommand]
    private void Navigate(MenuItemViewModel? clickMenu)
    {
        if (clickMenu is null || clickMenu.IsActive) return;

        clickMenu.IsActive = true;

        foreach (var menuItemViewModel in MenuSources)
        {
            if (menuItemViewModel == clickMenu) continue;

            menuItemViewModel.IsActive = false;
        }

        _navigationService.NavigateTo(clickMenu.ViewName);
    }

    [RelayCommand]
    private void ClearSearchVal()
    {
        SearchVal = string.Empty;
    }

    #endregion

    #region Constructors

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public AppMenuViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
    }

    public AppMenuViewModel(INavigationService navigationService, ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        _navigationService = navigationService;
        _searchValChanged.Throttle(TimeSpan.FromMilliseconds(300))
            .DistinctUntilChanged()
            .Subscribe(OnSearch);
    }

    #endregion
}
