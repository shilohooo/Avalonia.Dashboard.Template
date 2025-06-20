using Avalonia.Controls;
using Avalonia.Dashboard.Ui.ViewModels;
using Avalonia.Input;

namespace Avalonia.Dashboard.Ui.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        PointerPressed += OnPointerPressed;
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