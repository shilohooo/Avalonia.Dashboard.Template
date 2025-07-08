using Avalonia.Dashboard.Abstractions.Services;
using Avalonia.Dashboard.Common.Helpers;
using Avalonia.Dashboard.Domains.Models;

namespace Avalonia.Dashboard.Services;

/// <summary>
///     Menu service impl
/// </summary>
public class MenuService : IMenuService
{
    /// <inheritdoc />
    public List<MenuItem> GetMenuItems()
    {
        var menuJsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs", "menus.json");
        var menusJsonStr = File.ReadAllText(menuJsonFilePath);
        return JsonHelper.Deserialize<List<MenuItem>>(menusJsonStr) ?? [];
    }
}
