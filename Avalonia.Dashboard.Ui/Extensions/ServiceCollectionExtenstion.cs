using System.Reflection;
using Avalonia.Dashboard.Abstractions.Factories;
using Avalonia.Dashboard.Ui.Factories;
using Avalonia.Dashboard.Ui.Views;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.Dashboard.Ui.Extensions;

/// <summary>
///     依赖注入
/// </summary>
public static class ServiceCollectionExtenstion
{
    /// <summary>
    ///     注入 Ui 相关服务
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddUiServices(this IServiceCollection serviceCollection)
    {
        var serviceTypes = Assembly.GetAssembly(typeof(MainWindow))!
            .GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } && t.FullName!.EndsWith("Service"))
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

        // 主窗口
        serviceCollection.AddSingleton<MainWindow>();
        serviceCollection.AddSingleton<Lazy<MainWindow>>(provider =>
            new Lazy<MainWindow>(provider.GetRequiredService<MainWindow>));
        serviceCollection.AddSingleton<IViewModelFactory, DefaultViewModelFactory>();
        serviceCollection.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
    }

    /// <summary>
    ///     注入 View Model
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddViewModels<TViewModel>(this IServiceCollection serviceCollection)
    {
        var baseVmType = typeof(TViewModel);
        var vmTypes = Assembly.GetAssembly(baseVmType)!
            .GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } && baseVmType.IsAssignableFrom(t));
        foreach (var vmType in vmTypes) serviceCollection.AddTransient(vmType);
    }

    /// <summary>
    ///     注入页面（Views）
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddViews(this IServiceCollection serviceCollection)
    {
        var viewTypes = Assembly.GetAssembly(typeof(MainWindow))!
            .GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } && t.FullName!.EndsWith("View"))
            .ToList();
        foreach (var viewType in viewTypes) serviceCollection.AddTransient(viewType);
    }
}