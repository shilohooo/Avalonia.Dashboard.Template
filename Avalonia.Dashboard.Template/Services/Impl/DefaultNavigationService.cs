using System;
using System.Diagnostics;
using Avalonia.Dashboard.Template.Messages;
using Avalonia.Dashboard.Template.ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.Dashboard.Template.Services.Impl;

/// <summary>
///     导航服务的默认实现
/// </summary>
public class DefaultNavigationService : INavigationService
{
    /// <summary>
    /// 当前页面对应的 view model
    /// </summary>
    public ViewModelBase? CurrentPage { get; private set; }

    /// <inheritdoc />
    public void NavigateTo(Type vmType)
    {
        if (!typeof(ViewModelBase).IsAssignableFrom(vmType))
        {
            Debug.WriteLine($"页面导航出错：{vmType} 不是 {nameof(ViewModelBase)} 类型");
            return;
        }

        CurrentPage = ServiceLocator.Host.Services.GetRequiredService(vmType) as ViewModelBase;
        WeakReferenceMessenger.Default.Send(new CurrentPageChangedMessage(CurrentPage));
    }
}