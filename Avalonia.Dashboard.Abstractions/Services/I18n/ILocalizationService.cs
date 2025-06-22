using System.Globalization;

namespace Avalonia.Dashboard.Abstractions.Services.I18n;

/// <summary>
/// 
/// </summary>
public interface ILocalizationService
{
    /// <summary>
    /// Gets or Sets the current culture.
    /// </summary>
    CultureInfo CurrentCulture { get; set; }
    
    /// <summary>
    /// Gets the localized string for the given key.
    /// </summary>
    /// <param name="key">key</param>
    string this[string key] { get; }
}