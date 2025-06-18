using Avalonia.Controls;
using Avalonia.Dashboard.Ui.ViewModels;

namespace Avalonia.Dashboard.Ui.Views;

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