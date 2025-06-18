using Avalonia.Dashboard.Abstractions.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Avalonia.Dashboard.Ui.Messages;

/// <summary>
///     当前页面变更消息
/// </summary>
public class CurrentPageChangedMessage(IViewModel? currentPage) : ValueChangedMessage<IViewModel?>(currentPage);