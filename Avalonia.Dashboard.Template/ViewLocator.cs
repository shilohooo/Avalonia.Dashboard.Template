using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Dashboard.Abstractions.ViewModels;
using Avalonia.Dashboard.Ui;
using Avalonia.Dashboard.Ui.Views;

namespace Avalonia.Dashboard.Template;

public class ViewLocator : IDataTemplate
{
    public Control Build(object? param)
    {
        if (param is null)
            return new TextBlock { Text = "Null view-model:(" };

        var viewTypeName = param.GetType().FullName!.Replace("ViewModel", "View");
        var assemblyFullName = typeof(MainWindow).Assembly.FullName;
        var viewAssemblyQualifiedName = $"{viewTypeName}, {assemblyFullName}";
        var viewType = Type.GetType(viewAssemblyQualifiedName);
        var notFound = new TextBlock { Text = "View not found for " + viewTypeName };
        if (viewType is null || ServiceLocator.GetRequiredService(viewType) is not Control view) return notFound;

        return view;
    }

    public bool Match(object? data)
    {
        return data is IViewModel;
    }
}