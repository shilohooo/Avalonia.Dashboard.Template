using System;
using System.Threading;
using Avalonia.Dashboard.App.Extensions;
using Serilog;

namespace Avalonia.Dashboard.App;

internal static class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        try
        {
            Thread.CurrentThread.Name ??= "MainThread";

            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e, "Unknown error occurs:(");
        }
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    private static AppBuilder BuildAvaloniaApp()
    {
        return CustomAppBuilderExtension.BuildAvaloniaAppWithDi();
    }
}
