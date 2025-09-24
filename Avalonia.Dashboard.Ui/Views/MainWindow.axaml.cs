using Avalonia.Controls;
using Avalonia.Dashboard.Ui.ViewModels;
using Avalonia.Input;
using Microsoft.Extensions.Logging;

namespace Avalonia.Dashboard.Ui.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
    }

    public MainWindow(MainWindowViewModel viewModel, ILogger<MainWindow> logger)
    {
        InitializeComponent();
        DataContext = viewModel;
        PointerPressed += OnPointerPressed;
        logger.LogInformation("MainWindow created");
    }

    /// <summary>
    ///     实现无边框窗口拖动
    /// </summary>
    /// <returns></returns>
    private void OnPointerPressed(object? _, PointerPressedEventArgs e)
    {
        if (e.Pointer.Type is not PointerType.Mouse) return;

        BeginMoveDrag(e);
    }
}
