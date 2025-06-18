using Avalonia.Controls;
using Avalonia.Dashboard.Template.ViewModels;

namespace Avalonia.Dashboard.Template.Views;

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