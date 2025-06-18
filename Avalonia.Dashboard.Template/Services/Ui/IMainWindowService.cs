namespace Avalonia.Dashboard.Template.Services.Ui;

/// <summary>
///     主窗口管理服务
/// </summary>
public interface IMainWindowService
{
    /// <summary>
    ///     最小化主窗口
    /// </summary>
    void Minimize();

    /// <summary>
    ///     主窗口放大/缩小
    /// </summary>
    void Maximize();

    /// <summary>
    ///     关闭主窗口
    /// </summary>
    void Close();
}