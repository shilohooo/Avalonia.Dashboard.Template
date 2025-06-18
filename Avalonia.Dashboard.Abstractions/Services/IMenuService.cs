using Avalonia.Dashboard.Domains.Models;

namespace Avalonia.Dashboard.Abstractions.Services;

/// <summary>
///     菜单管理服务
/// </summary>
public interface IMenuService
{
    /// <summary>
    ///     获取菜单列表
    /// </summary>
    /// <returns>菜单列表</returns>
    List<MenuItem> GetMenuItems();
}