using Avalonia.Dashboard.Ui.Assets.I18n;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     主页视图模型
/// </summary>
public class HomeViewModel : ViewModelBase
{
    public static string Title => Resources.Greeting;
}