using Avalonia.Controls;
using AppHeaderViewModel = Avalonia.Dashboard.Ui.ViewModels.AppHeaderViewModel;

namespace Avalonia.Dashboard.Ui.Controls;

public partial class AppHeader : UserControl
{
    public AppHeader()
    {
        InitializeComponent();
        DataContext = ServiceLocator.GetRequiredService<AppHeaderViewModel>();
    }
}