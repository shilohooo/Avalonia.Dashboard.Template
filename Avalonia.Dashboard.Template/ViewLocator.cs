using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Dashboard.Template.ViewModels;

namespace Avalonia.Dashboard.Template;

public class ViewLocator : IDataTemplate
{
    public Control Build(object? param)
    {
        if (param is null)
            return new TextBlock { Text = "Null view-model:(" };

        var viewTypeName = param.GetType().FullName!.Replace("ViewModel", "View");
        var viewType = Type.GetType(viewTypeName);
        var notFound = new TextBlock { Text = "View not found for " + viewTypeName };
        if (viewType is null || ServiceLocator.GetRequiredService(viewType) is not Control view) return notFound;

        return view;
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}