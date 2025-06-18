using Avalonia.Dashboard.Domains.Enums;

namespace Avalonia.Dashboard.Abstractions.Services.Ui;

/// <summary>
///     导航服务
/// </summary>
public interface INavigationService
{
    /// <summary>
    ///     导航到指定页面
    /// </summary>
    /// <param name="viewName">页面视图名称</param>
    void NavigateTo(ViewName viewName);
}