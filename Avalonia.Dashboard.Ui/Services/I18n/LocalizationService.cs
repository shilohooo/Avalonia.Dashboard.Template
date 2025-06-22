using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Avalonia.Dashboard.Abstractions.Services.I18n;
using Avalonia.Dashboard.Ui.Messages;
using Avalonia.Dashboard.Ui.Views;
using CommunityToolkit.Mvvm.Messaging;

namespace Avalonia.Dashboard.Ui.Services.I18n;

/// <summary>
/// Implementation of <see cref="ILocalizationService"/>
/// </summary>
public class LocalizationService(IMessenger messenger) : ILocalizationService
{
    private readonly ResourceManager _resourceManager = new("Avalonia.Dashboard.Ui.Assets.I18n.Resources",
        Assembly.GetAssembly(typeof(MainWindow))!);

    private CultureInfo _currentCulture = CultureInfo.CurrentCulture;

    /// <inheritdoc />
    public CultureInfo CurrentCulture
    {
        get => _currentCulture;
        set
        {
            if (_currentCulture.Equals(value))
            {
                return;
            }
            _currentCulture = value;
            
            CultureInfo.CurrentCulture = CurrentCulture;
            CultureInfo.CurrentUICulture = CurrentCulture;
            CultureInfo.DefaultThreadCurrentCulture = CurrentCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CurrentCulture;
            
            messenger.Send(new CurrentCultureChangedMessage(_currentCulture));
        }
    }

    /// <inheritdoc />
    public string this[string key] => _resourceManager.GetString(key, _currentCulture) ?? $"!Localized content missing for key [{key}]!";
}