using Avalonia.Controls;
using Avalonia.Dashboard.Ui.ViewModels;

namespace Avalonia.Dashboard.Ui.Controls;

public partial class AppSidebar : UserControl
{
    public AppSidebar()
    {
        InitializeComponent();
        DataContext = ServiceLocator.GetRequiredService<AppSidebarViewModel>();
    }
}