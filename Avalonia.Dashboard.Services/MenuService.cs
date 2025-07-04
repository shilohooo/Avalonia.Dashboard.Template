using Avalonia.Dashboard.Abstractions.Services;
using Avalonia.Dashboard.Domains.Enums;
using Avalonia.Dashboard.Domains.Models;

namespace Avalonia.Dashboard.Services;

/// <summary>
///     菜单服务实现
/// </summary>
public class MenuService : IMenuService
{
    /// <inheritdoc />
    public List<MenuItem> GetMenuItems()
    {
        return
        [
            new MenuItem { Title = "HomeMenuTitle", Icon = "Home", ViewName = ViewName.Home },
            new MenuItem { Title = "AboutMenuTitle", Icon = "InfoRounded", ViewName = ViewName.About }
        ];
    }
}