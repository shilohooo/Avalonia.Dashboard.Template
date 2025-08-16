using System.Collections.ObjectModel;
using Avalonia.Dashboard.Domains.Models;

namespace Avalonia.Dashboard.Ui.ViewModels.Workspace;

/// <summary>
///     ViewModel of <see cref="Avalonia.Dashboard.Ui.Controls.Workspace.TodoList" /> user control
/// </summary>
public class TodoListViewModel : ViewModelBase
{
    public ObservableCollection<TodoItem> TodoItems { get; set; } = [];

    public TodoListViewModel()
    {
        TodoItems.Clear();

        TodoItems.Add(new TodoItem
        {
            Title = "Complete project requirements analysis",
            Description = "Confirm all functional requirements with product manager"
        });
        TodoItems.Add(new TodoItem
        {
            Title = "Design database structure",
            IsCompleted = true,
            Description = "Complete ER diagram design and field definitions"
        });
        TodoItems.Add(new TodoItem
        {
            Title = "Implement user login functionality",
            Description = "Include login validation and token generation"
        });
        TodoItems.Add(new TodoItem
        {
            Title = "Write unit tests", Description = "Create test cases for core business logic"
        });
        TodoItems.Add(new TodoItem
        {
            Title = "Optimize frontend performance", IsCompleted = true, Description = "Reduce initial page load time"
        });
        // TodoItems.Add(new TodoItem
        //     { Title = "Fix known bugs", Description = "Address three major issues reported by users" });
        // TodoItems.Add(new TodoItem
        // {
        //     Title = "Prepare project demo documentation",
        //     Description = "Create product feature demonstration PPT"
        // });
        // TodoItems.Add(new TodoItem
        // {
        //     Title = "Deploy to test environment",
        //     Description = "Configure server and database",
        //     IsCompleted = true
        // });
        // TodoItems.Add(new TodoItem { Title = "Code review", Description = "Review code submitted by team members" });
        // TodoItems.Add(new TodoItem
        //     { Title = "Plan next iteration", Description = "Outline development tasks for next month" });
    }
}
