using System.Diagnostics;
using Avalonia.Dashboard.Abstractions.Services;

namespace Avalonia.Dashboard.Services;

/// <summary>
///     Default implementation of <see cref="IBrowserService" />
/// </summary>
public class BrowserService : IBrowserService
{
    /// <inheritdoc />
    public void OpenPage(string? url)
    {
        if (string.IsNullOrWhiteSpace(url)) return;

        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
}
