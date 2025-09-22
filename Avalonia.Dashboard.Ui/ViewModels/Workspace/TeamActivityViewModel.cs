using System.Diagnostics;
using Avalonia.Dashboard.Abstractions.Services;
using Avalonia.Dashboard.Domains.Models;

namespace Avalonia.Dashboard.Ui.ViewModels.Workspace;

/// <summary>
///     ViewModel of <see cref="Avalonia.Dashboard.Ui.Controls.Workspace.TeamActivity" />>
/// </summary>
public class TeamActivityViewModel : ViewModelBase
{
    /// <summary>
    ///     Team activities
    /// </summary>
    public List<ActivityLog> ActivityLogs { get; set; } = [];

    #region Constructors

    public TeamActivityViewModel()
    {
        // for preview only
    }

    public TeamActivityViewModel(IActivityLogService activityLogService)
    {
        ActivityLogs = activityLogService.GetActivityLogsAsync();
        Debug.WriteLine($"init activity logs: {ActivityLogs.Count}");
    }

    #endregion
}
