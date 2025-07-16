using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     View model of <see cref="Views.BugReportView" />
/// </summary>
public partial class BugReportViewModel(IConfiguration configuration) : ViewModelBase
{
    private string BugReportUrl => configuration["Links:BugReport"]!;

    #region Commands

    /// <summary>
    ///     Use default browser to open bug report page
    /// </summary>
    [RelayCommand]
    private void OpenBugReportPage()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = BugReportUrl,
            UseShellExecute = true
        });
    }

    #endregion
}
