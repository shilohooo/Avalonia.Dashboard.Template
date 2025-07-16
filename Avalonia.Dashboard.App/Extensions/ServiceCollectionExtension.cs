using Avalonia.Dashboard.Common.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.Dashboard.App.Extensions;

/// <summary>
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    ///     Add <see cref="IConfiguration" /> as a singleton service
    ///     <param name="serviceCollection">
    ///         <see cref="IServiceCollection" />
    ///     </param>
    /// </summary>
    public static void AddAppConfiguration(this IServiceCollection serviceCollection)
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile(GlobalConstants.AppSettingsFilename)
            .Build();
        serviceCollection.AddSingleton(config);
    }
}
