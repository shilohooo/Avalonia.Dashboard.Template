using Avalonia.Controls;
using Avalonia.Dashboard.Abstractions.Services.Ui;
using Avalonia.Input;
using AppHeaderViewModel = Avalonia.Dashboard.Ui.ViewModels.AppHeaderViewModel;

namespace Avalonia.Dashboard.Ui.Controls;

public partial class AppHeader : UserControl
{
    private readonly IMainWindowService _mainWindowService;

    public AppHeader()
    {
        InitializeComponent();
        DataContext = ServiceLocator.GetRequiredService<AppHeaderViewModel>();
        _mainWindowService = ServiceLocator.GetRequiredService<IMainWindowService>();

        PointerPressed += OnHeaderDoubleClick;
    }

    /// <summary>
    ///     Handle title bar double click event: set main window state to maximized or normal
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnHeaderDoubleClick(object? sender, PointerPressedEventArgs e)
    {
        if (e.ClickCount != 2) return;

        var source = e.Source as Control;

        if (source is Button) return;

        _mainWindowService.ToggleMaximize();
    }
}