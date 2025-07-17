namespace Avalonia.Dashboard.Abstractions.Services;

/// <summary>
/// </summary>
public interface IBrowserService
{
    /// <summary>
    ///     Use default browser to open a page
    /// </summary>
    /// <param name="url">url to open</param>
    void OpenPage(string? url);
}
