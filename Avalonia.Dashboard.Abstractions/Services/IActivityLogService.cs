using Avalonia.Dashboard.Domains.Models;

namespace Avalonia.Dashboard.Abstractions.Services;

/// <summary>
/// </summary>
public interface IActivityLogService
{
    /// <summary>
    ///     Get activity logs from json file
    /// </summary>
    /// <returns>activity logs</returns>
    List<ActivityLog> GetActivityLogsAsync();
}
