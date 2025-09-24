using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Dashboard.Abstractions.Services.I18n;
using Avalonia.Dashboard.Ui;
using Avalonia.Dashboard.Ui.Views;
using Avalonia.Data.Core.Plugins;
using Avalonia.Diagnostics;
using Avalonia.Markup.Xaml;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;

namespace Avalonia.Dashboard.App;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        // customize LiveCharts
        LiveCharts.Configure(config =>
        {
            config
                .AddDarkTheme()
                .AddLightTheme()
                // Chinese font
                .HasGlobalSKTypeface(SKFontManager.Default.MatchCharacter('汉'))
                .UseRightToLeftSettings();
        });
    }

    public override void OnFrameworkInitializationCompleted()
    {
        // set default language to English 
        var localizationService = ServiceLocator.GetRequiredService<ILocalizationService>();
        localizationService.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            var mainWindow = ServiceLocator.GetRequiredService<MainWindow>();
            desktop.MainWindow = mainWindow;

#if DEBUG
            mainWindow.AttachDevTools(new DevToolsOptions
            {
                StartupScreenIndex = 1
            });
#endif
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove) BindingPlugins.DataValidators.Remove(plugin);
    }
}
