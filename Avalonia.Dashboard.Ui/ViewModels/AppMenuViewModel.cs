using System.Collections.ObjectModel;
using Avalonia.Dashboard.Abstractions.Services.I18n;
using Avalonia.Dashboard.Abstractions.Services.Ui;
using Avalonia.Dashboard.Ui.Assets.I18n;
using Avalonia.Dashboard.Ui.Messages;
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

    /// <summary>
    ///     Menu search placeholder
    /// </summary>
    public string MenuSearchPlaceholder => _localizationService[nameof(Resources.MenuSearchPlaceholder)];

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
            Menus = [];
            return;
        }

        Menus.Clear();
        foreach (var menuItemViewModel in message.Value)
        {
            menuItemViewModel.IsActive = false;
            Menus.Add(menuItemViewModel);
        }

        // navigate to first sub menu
        var firstMenu = message.Value[0];
        firstMenu.IsActive = true;
        _navigationService.NavigateTo(firstMenu.ViewName);
    }

    #region Commands

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

        _navigationService.NavigateTo(clickMenu.ViewName);
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
    }

    #endregion
}
