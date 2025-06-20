using Avalonia.Dashboard.Abstractions.ViewModels;
using Avalonia.Dashboard.Ui.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     主窗口 vm
/// </summary>
public partial class MainWindowViewModel : RecipientViewModelBase, IRecipient<ThemeChangedMessage>,
    IRecipient<MainWindowStateChangedMessage>, IRecipient<CurrentPageChangedMessage>, IRecipient<SidebarToggleMessage>
{
    /// <summary>
    ///     当前页面对应的视图模型
    /// </summary>
    [ObservableProperty] private IViewModel? _currentPage;

    /// <summary>
    ///     当前主题是否为暗色主题
    /// </summary>
    [ObservableProperty] private bool _isDarkMode = true;

    /// <summary>
    ///     当前是否全屏
    /// </summary>
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(MainWindowPadding))]
    private bool _isMaximized;

    /// <summary>
    ///     侧边栏导航区域展开状态
    /// </summary>
    [ObservableProperty] private bool _isSidebarOpened = true;

    /// <summary>
    ///     主窗口内边距
    /// </summary>
    public Thickness MainWindowPadding => IsMaximized ? new Thickness(8) : new Thickness(0);

    /// <inheritdoc />
    public void Receive(CurrentPageChangedMessage message)
    {
        CurrentPage = message.Value;
    }

    /// <inheritdoc />
    public void Receive(MainWindowStateChangedMessage message)
    {
        IsMaximized = message.Value;
    }

    /// <inheritdoc />
    public void Receive(SidebarToggleMessage message)
    {
        IsSidebarOpened = message.Value;
    }

    /// <inheritdoc />
    public void Receive(ThemeChangedMessage message)
    {
        IsDarkMode = message.Value;
    }
}