using Avalonia.Controls;
using Avalonia.Dashboard.Template.ViewModels;

namespace Avalonia.Dashboard.Template.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
    }

    public HomeView(HomeViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}