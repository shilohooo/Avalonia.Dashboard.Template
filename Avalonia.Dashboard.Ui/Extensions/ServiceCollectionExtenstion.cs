using Avalonia.Dashboard.Abstractions.Factories;
using Avalonia.Dashboard.Abstractions.Services.Ui;
using Avalonia.Dashboard.Ui.Factories;
using Avalonia.Dashboard.Ui.Services.Ui;
using Avalonia.Dashboard.Ui.ViewModels;
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
        serviceCollection.AddSingleton<IMainWindowService, MainWindowService>();
        // 主窗口
        serviceCollection.AddSingleton<MainWindow>();
        serviceCollection.AddSingleton<Lazy<MainWindow>>(provider =>
            new Lazy<MainWindow>(provider.GetRequiredService<MainWindow>));
        serviceCollection.AddSingleton<INavigationService, DefaultNavigationService>();
        serviceCollection.AddSingleton<IThemeService, ThemeService>();
        serviceCollection.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
        serviceCollection.AddSingleton<IViewModelFactory, DefaultViewModelFactory>();
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