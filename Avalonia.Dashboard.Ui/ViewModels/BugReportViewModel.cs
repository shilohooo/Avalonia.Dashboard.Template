using Avalonia.Dashboard.Abstractions.Services;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     View model of <see cref="Views.BugReportView" />
/// </summary>
public partial class BugReportViewModel(IConfiguration configuration, IBrowserService browserService) : ViewModelBase
{
    private string BugReportUrl => configuration["Links:BugReport"]!;

    #region Commands

    /// <summary>
    ///     Use default browser to open bug report page
    /// </summary>
    [RelayCommand]
    private void OpenBugReportPage()
    {
        browserService.OpenPage(BugReportUrl);
    }

    #endregion
}
