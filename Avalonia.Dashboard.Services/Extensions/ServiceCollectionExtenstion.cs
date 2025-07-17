using System.Reflection;
using Avalonia.Dashboard.Common.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.Dashboard.Services.Extensions;

/// <summary>
/// </summary>
public static class ServiceCollectionExtenstion
{
    /// <summary>
    ///     Add all services to IOC container
    /// </summary>
    /// <param name="serviceCollection">
    ///     <see cref="IServiceCollection" />
    /// </param>
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        var serviceTypes = Assembly.GetAssembly(typeof(MenuService))!
            .GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } &&
                        t.FullName!.EndsWith(GlobalConstants.ServiceClassNameSuffix))
            .ToList();
        foreach (var serviceType in serviceTypes)
        {
            var interfaces = serviceType.GetInterfaces();
            if (interfaces.Length == 0)
            {
                serviceCollection.AddSingleton(serviceType);
                continue;
            }

            foreach (var @interface in interfaces) serviceCollection.AddSingleton(@interface, serviceType);
        }
    }
}
