using Avalonia.Controls;
using Avalonia.Dashboard.Ui.ViewModels;

namespace Avalonia.Dashboard.Ui.Controls;

public partial class AppMenu : UserControl
{
    public AppMenu()
    {
        InitializeComponent();
        DataContext = ServiceLocator.GetRequiredService<AppMenuViewModel>();
    }
}
