using Avalonia.Dashboard.Services.Extensions;
using Avalonia.Dashboard.Ui;
using Avalonia.Dashboard.Ui.Extensions;
using Avalonia.Dashboard.Ui.ViewModels;
using Microsoft.Extensions.Hosting;

namespace Avalonia.Dashboard.Template.Extensions;

/// <summary>
/// </summary>
public static class CustomAppBuilderExtension
{
    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaAppWithDi()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
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