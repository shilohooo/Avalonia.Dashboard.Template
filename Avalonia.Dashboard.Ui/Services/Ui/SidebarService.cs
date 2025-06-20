using Avalonia.Dashboard.Abstractions.Services.Ui;
using Avalonia.Dashboard.Ui.Messages;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Ui.Services.Ui;

/// <summary>
///     Sidebar service implementation
/// </summary>
public class SidebarService(IMessenger messenger) : ISidebarService
{
    /// <summary>
    ///     Sidebar opened state
    /// </summary>
    private bool IsSidebarOpened { get; set; } = true;

    /// <inheritdoc />
    public void ToggleSidebar()
    {
        IsSidebarOpened = !IsSidebarOpened;
        messenger.Send(new SidebarToggleMessage(IsSidebarOpened));
    }
}