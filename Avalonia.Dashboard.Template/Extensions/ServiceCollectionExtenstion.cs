using System;
using Avalonia.Dashboard.Template.Services;
using Avalonia.Dashboard.Template.Services.Impl;
using Avalonia.Dashboard.Template.ViewModels;
using Avalonia.Dashboard.Template.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.Dashboard.Template.Extensions;

/// <summary>
///     依赖注入
/// </summary>
public static class ServiceCollectionExtenstion
{
    /// <summary>
    ///     注入通用服务
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMainWindowService, MainWindowService>();
        // 主窗口
        serviceCollection.AddSingleton<MainWindow>();
        serviceCollection.AddSingleton<Lazy<MainWindow>>(provider =>
            new Lazy<MainWindow>(provider.GetRequiredService<MainWindow>));
        serviceCollection.AddSingleton<INavigationService, DefaultNavigationService>();
        serviceCollection.AddSingleton<IThemeService, ThemeService>();
    }

    /// <summary>
    ///     注入 View Model
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddViewModels(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<MainWindowViewModel>();
        serviceCollection.AddTransient<AppHeaderViewModel>();

        // page view model
        serviceCollection.AddTransient<HomeViewModel>();
        serviceCollection.AddTransient<AboutViewModel>();
    }

    /// <summary>
    ///     注入页面（Views）
    /// </summary>
    /// <param name="serviceCollection"></param>
    public static void AddViews(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<HomeView>();
        serviceCollection.AddTransient<AboutView>();
    }
}