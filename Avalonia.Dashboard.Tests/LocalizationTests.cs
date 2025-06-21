using System.Globalization;
using System.Reflection;
using System.Resources;
using Avalonia.Dashboard.Ui.Views;

namespace Avalonia.Dashboard.Tests;

/// <summary>
/// </summary>
public class LocalizationTests
{
    [Fact]
    public void TestGetGreeting()
    {
        var resourceManager =
            new ResourceManager("Avalonia.Dashboard.Ui.Assets.I18n.Resources",
                Assembly.GetAssembly(typeof(MainWindow))!);
        var cultureInfo = new CultureInfo("en-US");
        var greeting = resourceManager.GetString("Greeting", cultureInfo);
        Assert.NotNull(greeting);
        Assert.Equal("Hello, Avalonia", greeting);
        cultureInfo = new CultureInfo("zh-CN");
        greeting = resourceManager.GetString("Greeting", cultureInfo);
        Assert.NotNull(greeting);
        Assert.Equal("你好，Avalonia", greeting);
    }
}