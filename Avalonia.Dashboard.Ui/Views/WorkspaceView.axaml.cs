using Avalonia.Controls;
using Avalonia.Dashboard.Ui.ViewModels;

namespace Avalonia.Dashboard.Ui.Views;

public partial class WorkspaceView : UserControl
{
    public WorkspaceView()
    {
    }

    public WorkspaceView(WorkspaceViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
