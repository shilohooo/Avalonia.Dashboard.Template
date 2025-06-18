using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Avalonia.Dashboard.Template.Messages;

/// <summary>
///     主窗口状态变更消息
/// </summary>
public class MainWindowStateChangedMessage(bool isMaximized) : ValueChangedMessage<bool>(isMaximized);