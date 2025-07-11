using Avalonia.Controls;
using Avalonia.Dashboard.Ui.ViewModels;

namespace Avalonia.Dashboard.Ui.Views;

public partial class BugReportView : UserControl
{
    public BugReportView()
    {
    }

    public BugReportView(BugReportViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
