using System.Text.Json;
using Avalonia.Dashboard.Abstractions.Services;
using Avalonia.Dashboard.Domains;
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
        return JsonSerializer.Deserialize<List<ActivityLog>>(activityLogsJsonStr,
            AppJsonSerializerContext.Default.ListActivityLog) ?? [];
    }
}
