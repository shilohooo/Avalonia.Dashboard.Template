namespace Avalonia.Dashboard.Domains.Models;

/// <summary>
///     Activity Log
/// </summary>
public class ActivityLog
{
    /// <summary>
    ///     Id
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    ///     UserName
    /// </summary>
    public required string UserName { get; set; }

    /// <summary>
    ///     User position
    /// </summary>
    public string? Position { get; set; }

    /// <summary>
    ///     Title
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    ///     Content
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    ///     Create time
    /// </summary>
    public DateTimeOffset CreateTime { get; set; } = DateTimeOffset.Now;
}
