using System;
using Avalonia.Controls;
using Avalonia.Dashboard.Template.Messages;
using Avalonia.Dashboard.Template.Views;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Template.Services.Impl;

/// <summary>
///     主窗口管理服务实现
/// </summary>
public class MainWindowService(Lazy<MainWindow> mainWindow) : IMainWindowService
{
    /// <summary>
    /// 主窗口是否处于最大化
    /// </summary>
    public bool IsMaximized { get; private set; }

    /// <inheritdoc />
    public void Minimize()
    {
        mainWindow.Value.WindowState = WindowState.Minimized;
    }

    /// <inheritdoc />
    public void Maximize()
    {
        mainWindow.Value.WindowState = mainWindow.Value.WindowState switch
        {
            WindowState.Normal => WindowState.Maximized,
            WindowState.Maximized => WindowState.Normal,
            _ => mainWindow.Value.WindowState
        };
        IsMaximized = mainWindow
            .Value.WindowState == WindowState.Maximized;

        // 发布窗口最大化状态改变消息
        WeakReferenceMessenger.Default.Send(new MainWindowStateChangedMessage(IsMaximized));
    }

    /// <inheritdoc />
    public void Close()
    {
        mainWindow.Value.Close();
    }
}