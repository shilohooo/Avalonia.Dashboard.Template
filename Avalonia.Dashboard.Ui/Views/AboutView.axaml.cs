using Avalonia.Controls;
using Avalonia.Dashboard.Ui.ViewModels;

namespace Avalonia.Dashboard.Ui.Views;

public partial class AboutView : UserControl
{
    public AboutView()
    {
    }

    public AboutView(AboutViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}