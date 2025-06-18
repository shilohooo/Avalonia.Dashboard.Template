using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Input;

namespace Avalonia.Dashboard.Ui.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        Debug.WriteLine("主窗口构造");
        InitializeComponent();
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