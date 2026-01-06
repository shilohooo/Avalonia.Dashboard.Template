using System.Text.Json;
using Avalonia.Dashboard.Abstractions.Services;
using Avalonia.Dashboard.Domains;
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
        return JsonSerializer.Deserialize<List<MenuItem>>(menusJsonStr,
            AppJsonSerializerContext.Default.ListMenuItem) ?? [];
    }
}
