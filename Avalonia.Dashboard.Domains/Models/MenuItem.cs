using Avalonia.Dashboard.Domains.Enums;

namespace Avalonia.Dashboard.Domains.Models;

/// <summary>
///     菜单项 model
/// </summary>
public class MenuItem
{
    /// <summary>
    ///     菜单标题
    /// </summary>
    public required string Title { get; init; }

    /// <summary>
    ///     菜单图标
    /// </summary>
    public string Icon { get; init; }

    /// <summary>
    ///     菜单对应的页面类型
    /// </summary>
    public required ViewName ViewName { get; init; }
}