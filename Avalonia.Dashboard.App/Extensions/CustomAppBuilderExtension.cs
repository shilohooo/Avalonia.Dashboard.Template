using System;
using Avalonia.Dashboard.Services.Extensions;
using Avalonia.Dashboard.Ui;
using Avalonia.Dashboard.Ui.Extensions;
using Avalonia.Dashboard.Ui.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Path = System.IO.Path;

namespace Avalonia.Dashboard.App.Extensions;

/// <summary>
/// </summary>
public static class CustomAppBuilderExtension
{
    private const string LogPattern =
        "{Timestamp:yyyy-MM-dd HH:mm:ss} {Level,-5} [{SourceContext,-20}] - {Message:lj}{NewLine}{Exception}";
    
    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaAppWithDi()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddAppConfiguration();

                services.AddLogging(builder =>
                {
                    builder.ClearProviders();

                    var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "App-.log");
                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console(outputTemplate: LogPattern)
                        .WriteTo.File(
                            logPath,
                            rollingInterval: RollingInterval.Day,
                            retainedFileCountLimit: 7,
                            outputTemplate: LogPattern
                        )
                        .CreateLogger();
                    builder.AddSerilog();
                });

                services.AddServices();

                services.AddViewModels<ViewModelBase>();
                services.AddViewModels<RecipientViewModelBase>();
                services.AddUiServices();
                services.AddViews();
            })
            .Build();
        ServiceLocator.Host = host;

        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
    }
}
