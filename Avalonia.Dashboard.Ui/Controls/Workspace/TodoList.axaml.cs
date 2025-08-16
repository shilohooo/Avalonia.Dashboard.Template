using Avalonia.Controls;
using Avalonia.Dashboard.Ui.ViewModels.Workspace;

namespace Avalonia.Dashboard.Ui.Controls.Workspace;

public partial class TodoList : UserControl
{
    public TodoList()
    {
        InitializeComponent();
        DataContext = ServiceLocator.GetRequiredService<TodoListViewModel>();
    }
}
