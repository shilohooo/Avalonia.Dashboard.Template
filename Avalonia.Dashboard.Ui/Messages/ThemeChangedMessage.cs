using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Avalonia.Dashboard.Ui.Messages;

/// <summary>
///     主题变更消息
/// </summary>
public class ThemeChangedMessage(bool value) : ValueChangedMessage<bool>(value);