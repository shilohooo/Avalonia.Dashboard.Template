namespace Avalonia.Dashboard.Domains.Models;

/// <summary>
/// </summary>
public class TodoItem
{
    /// <summary>
    ///     ID
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    ///     Title
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    ///     Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     Create time
    /// </summary>
    public DateTime CreateTime { get; set; } = DateTime.Now;

    /// <summary>
    ///     Flag of completed
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return Title;
    }
}
