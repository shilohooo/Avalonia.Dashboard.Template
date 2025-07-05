using Avalonia.Dashboard.Abstractions.Services.I18n;
using Avalonia.Dashboard.Ui.Assets.I18n;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     view model of <see cref="Avalonia.Dashboard.Ui.Controls.AppMenu" />
/// </summary>
public class AppMenuViewModel(ILocalizationService localizationService) : RecipientViewModelBase
{
    public string MenuAreaPlaceholder => localizationService[nameof(Resources.MenuAreaPlaceholder)];
    public string MenuSearchPlaceholder => localizationService[nameof(Resources.MenuSearchPlaceholder)];
}