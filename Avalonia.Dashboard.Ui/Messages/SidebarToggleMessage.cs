using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Avalonia.Dashboard.Ui.Messages;

/// <summary>
/// </summary>
public class SidebarToggleMessage(bool isSidebarOpened) : ValueChangedMessage<bool>(isSidebarOpened);