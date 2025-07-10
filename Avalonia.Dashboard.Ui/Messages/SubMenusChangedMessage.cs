using Avalonia.Dashboard.Ui.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Avalonia.Dashboard.Ui.Messages;

/// <summary>
/// </summary>
public class SubMenusChangedMessage(List<MenuItemViewModel> subMenus)
    : ValueChangedMessage<List<MenuItemViewModel>>(subMenus);
