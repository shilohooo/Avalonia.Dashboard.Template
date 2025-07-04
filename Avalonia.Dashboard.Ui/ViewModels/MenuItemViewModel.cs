﻿using Avalonia.Dashboard.Abstractions.Services.I18n;
using Avalonia.Dashboard.Domains.Enums;
using Avalonia.Dashboard.Domains.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     菜单项 view model
/// </summary>
public partial class MenuItemViewModel(MenuItem menu, ILocalizationService localizationService) : RecipientViewModelBase
{
    /// <summary>
    ///     菜单是否激活
    /// </summary>
    [ObservableProperty] private bool _isActive;

    /// <summary>
    ///     Readonly menu title resource key
    /// </summary>
    private readonly string _titleResourceKey = menu.Title;

    /// <summary>
    ///     菜单标题
    /// </summary>
    public string Title => localizationService[_titleResourceKey];

    /// <summary>
    ///     菜单图标
    /// </summary>
    public string Icon { get; set; } = menu.Icon;

    /// <summary>
    ///     菜单对应的页面类型
    /// </summary>
    public ViewName ViewName { get; } = menu.ViewName;
}