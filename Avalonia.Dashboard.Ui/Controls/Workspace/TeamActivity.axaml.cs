using Avalonia;
using Avalonia.Controls;
using Avalonia.Dashboard.Ui.ViewModels.Workspace;
using Avalonia.Markup.Xaml;

namespace Avalonia.Dashboard.Ui.Controls.Workspace;

public partial class TeamActivity : UserControl
{
    public TeamActivity()
    {
        InitializeComponent();
        DataContext = ServiceLocator.GetRequiredService<TeamActivityViewModel>();
    }
}

