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
    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaAppWithDi()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddAppConfiguration();

                services.AddLogging(builder =>
                {
                    builder.ClearProviders();

                    // var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    //     context.Configuration["Logging.Dir"]!, context.Configuration["Logging.FileName"]!);
                    Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(context.Configuration)
                        // .Enrich.WithThreadId()
                        // .Enrich.WithThreadName()
                        // .MinimumLevel.Debug()
                        // .WriteTo.Console(outputTemplate: context.Configuration["Logging.OutputTemplate"]!)
                        // .WriteTo.File(
                        //     logPath,
                        //     rollingInterval: RollingInterval.Day,
                        //     retainedFileCountLimit: 7,
                        //     outputTemplate: context.Configuration["Logging.OutputTemplate"]!
                        // )
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
