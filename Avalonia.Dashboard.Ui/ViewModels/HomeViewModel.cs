using Avalonia.Dashboard.Abstractions.Services.I18n;
using Avalonia.Dashboard.Ui.Assets.I18n;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     主页视图模型
/// </summary>
public class HomeViewModel : RecipientViewModelBase
{
    private readonly ILocalizationService _localizationService;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public HomeViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    {
        // for design time only
    }

    public HomeViewModel(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
    }

    public string Title => _localizationService[nameof(Resources.Greeting)];
}