using Avalonia.Dashboard.Abstractions.Services.I18n;
using Avalonia.Dashboard.Domains.Enums;
using Avalonia.Dashboard.Domains.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     菜单项 view model
/// </summary>
public partial class MenuItemViewModel : RecipientViewModelBase
{
    private readonly ILocalizationService _localizationService;

    /// <summary>
    ///     Readonly menu title resource key
    /// </summary>
    private readonly string _titleResourceKey;

    /// <summary>
    ///     Menu activation flag
    /// </summary>
    [ObservableProperty] private bool _isActive;

    #region Constructors

    public MenuItemViewModel(MenuItem menu, ILocalizationService localizationService)
    {
        _localizationService = localizationService;
        _titleResourceKey = menu.Title;
        Icon = menu.Icon;
        ViewName = menu.ViewName;
        Children = menu.Children
            .Select(item => new MenuItemViewModel(item, _localizationService))
            .ToList();
    }

    #endregion

    /// <summary>
    ///     Menu title
    /// </summary>
    public string Title => _localizationService[_titleResourceKey];

    /// <summary>
    ///     Menu icon
    /// </summary>
    public string Icon { get; set; }

    /// <summary>
    ///     The name of the page corresponding to the menu
    /// </summary>
    public ViewName? ViewName { get; }

    /// <summary>
    ///     Sub menus
    /// </summary>
    public List<MenuItemViewModel> Children { get; }
}
