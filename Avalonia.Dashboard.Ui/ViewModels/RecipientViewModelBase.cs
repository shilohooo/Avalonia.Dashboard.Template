using Avalonia.Dashboard.Abstractions.ViewModels;
using Avalonia.Dashboard.Ui.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     带消息订阅功能的 ViewModel 基类
/// </summary>
public class RecipientViewModelBase : ObservableRecipient, IDisposable, IViewModel,IRecipient<CurrentCultureChangedMessage>
{
    /// <summary>
    ///     资源是否已释放
    /// </summary>
    private bool _disposed;

    protected RecipientViewModelBase()
    {
        // 注册事件
        IsActive = true;
    }

    #region 释放资源

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing) IsActive = false;

        _disposed = true;
    }

    #endregion

    /// <inheritdoc />
    public void Receive(CurrentCultureChangedMessage message)
    {
        // Make all properties change
        OnPropertyChanged(string.Empty);
    }
}