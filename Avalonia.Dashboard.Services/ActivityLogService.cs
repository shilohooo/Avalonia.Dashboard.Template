using Avalonia.Dashboard.Abstractions.Services;
using Avalonia.Dashboard.Common.Helpers;
using Avalonia.Dashboard.Domains.Models;

namespace Avalonia.Dashboard.Services;

/// <summary>
/// </summary>
public class ActivityLogService : IActivityLogService
{
    /// <inheritdoc />
    public List<ActivityLog> GetActivityLogsAsync()
    {
        var jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "activity-logs.json");
        var activityLogsJsonStr = File.ReadAllText(jsonFilePath);
        return JsonHelper.Deserialize<List<ActivityLog>>(activityLogsJsonStr) ?? [];
    }
}
