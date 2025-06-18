using System.Collections.Immutable;
using System.Diagnostics;
using Avalonia.Dashboard.Abstractions.Services.Ui;
using Avalonia.Dashboard.Abstractions.ViewModels;
using Avalonia.Dashboard.Domains.Enums;
using Avalonia.Dashboard.Ui.Messages;
using Avalonia.Dashboard.Ui.ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.Dashboard.Ui.Services.Ui;

/// <summary>
///     导航服务的默认实现
/// </summary>
public class DefaultNavigationService(IMessenger messenger) : INavigationService
{
    private static readonly ImmutableDictionary<ViewName, Type> ViewMappings = ImmutableDictionary
        .Create<ViewName, Type>()
        .Add(ViewName.Home, typeof(HomeViewModel))
        .Add(ViewName.About, typeof(AboutViewModel));

    /// <summary>
    ///     当前页面对应的 view model
    /// </summary>
    private IViewModel? CurrentPage { get; set; }

    /// <inheritdoc />
    public void NavigateTo(ViewName viewName)
    {
        var vmType = ViewMappings[viewName];
        if (!typeof(IViewModel).IsAssignableFrom(vmType))
        {
            Debug.WriteLine($"页面导航出错：{viewName} 不是 {nameof(IViewModel)} 类型");
            return;
        }

        CurrentPage = ServiceLocator.Host.Services.GetRequiredService(vmType) as IViewModel;
        messenger.Send(new CurrentPageChangedMessage(CurrentPage));
    }
}