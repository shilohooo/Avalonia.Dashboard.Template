using Avalonia.Dashboard.Abstractions.ViewModels;

namespace Avalonia.Dashboard.Abstractions.Factories;

/// <summary>
///     View model Factory
/// </summary>
public interface IViewModelFactory
{
    /// <summary>
    ///     Create a view model instance by specified type
    /// </summary>
    /// <param name="vmType">The view model type</param>
    /// <returns>View model instance</returns>
    IViewModel? Create(Type vmType);
}