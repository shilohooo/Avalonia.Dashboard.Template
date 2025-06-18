using Avalonia.Controls;
using Avalonia.Dashboard.Template.ViewModels;

namespace Avalonia.Dashboard.Template.Controls;

public partial class AppHeader : UserControl
{
    public AppHeader()
    {
        InitializeComponent();
        DataContext = ServiceLocator.GetRequiredService<AppHeaderViewModel>();
    }
}