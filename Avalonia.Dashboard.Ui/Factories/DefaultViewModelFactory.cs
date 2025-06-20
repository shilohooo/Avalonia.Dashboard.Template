using Avalonia.Dashboard.Abstractions.Factories;
using Avalonia.Dashboard.Abstractions.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Avalonia.Dashboard.Ui.Factories;

/// <summary>
///     Default implementation of <see cref="IViewModelFactory" />
/// </summary>
public class DefaultViewModelFactory(IServiceProvider serviceProvider) : IViewModelFactory
{
    /// <inheritdoc />
    public IViewModel? Create(Type vmType)
    {
        return serviceProvider.GetRequiredService(vmType) as IViewModel;
    }
}