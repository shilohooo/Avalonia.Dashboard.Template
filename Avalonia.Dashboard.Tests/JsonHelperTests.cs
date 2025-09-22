using Avalonia.Dashboard.Common.Helpers;
using Avalonia.Dashboard.Domains.Models;

namespace Avalonia.Dashboard.Tests;

/// <summary>
/// </summary>
public class JsonHelperTests
{
    [Fact]
    public void TestDeserialize()
    {
        var jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "activity-logs.json");
        var jsonStr = File.ReadAllText(jsonFilePath);
        var activityLogs = JsonHelper.Deserialize<List<ActivityLog>>(jsonStr) ?? [];
        Assert.NotEmpty(activityLogs);
    }
}
