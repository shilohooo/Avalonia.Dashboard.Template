using Avalonia.Dashboard.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.Dashboard.Services.Extensions;

/// <summary>
/// </summary>
public static class ServiceCollectionExtenstion
{
    /// <summary>
    ///     注入服务
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMenuService, MenuServices>();
    }
}