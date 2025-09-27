# Avalonia Dashboard Template

> [!IMPORTANT]
> 🚧 The project is currently under active development and features are subject to change at any time.

A dashboard template for Avalonia UI, including a simple app layout and page navigation:)

This project can be used as a scaffold for building your own application.

Just enjoy it:)

## 🚀 Feature

- Common app layout: Header, Sidebar, Content
- Borderless main window
- Page navigation
- Dark/Light theme
- Dependency Injection
- HotReload
- Localization
    - [x] en-US
    - [x] zh-CN

## 🪲 Known BUGs

- [ ] i18n not working on Linux platform, such as Ubuntu.

## 📸 Screenshots

![Demo](./Screenshots/Avalonia.Dashboard.Template.gif)

## 💻 Stack

|                   Name                   |          Version           |                                    Docs                                    |                                                                Remark                                                                |
|:----------------------------------------:|:--------------------------:|:--------------------------------------------------------------------------:|:------------------------------------------------------------------------------------------------------------------------------------:|
|                   .NET                   |            8.0             |                   <https://dotnet.microsoft.com/en-us/>                    |                                                                                                                                      |
|                 Avalonia                 |           11.3.1           |                       <https://docs.avaloniaui.net/>                       |                                                                                                                                      |
|          CommunityToolkit.Mvvm           |           8.2.1            |     <https://learn.microsoft.com/en-us/dotnet/communitytoolkit/mvvm/>      |                                                                                                                                      |
|               HotAvalonia                |           3.0.0            |                  <https://github.com/Kira-NT/HotAvalonia>                  |                                                                                                                                      |
| Microsoft.Extensions.DependencyInjection | 10.0.0-preview.5.25277.114 | <https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/> |                                                                                                                                      |
|       Microsoft.Extensions.Hosting       | 10.0.0-preview.5.25277.114 |       <https://www.nuget.org/packages/Microsoft.Extensions.Hosting>        |                                                                                                                                      |
|       Microsoft.Extensions.Logging       | 10.0.0-preview.5.25277.114 |       <https://www.nuget.org/packages/Microsoft.Extensions.Logging>        |                                                                                                                                      |
|                 Serilog                  |            4.3             |                           <https://serilog.net/>                           |                                                                                                                                      |
|            Serilog.Sinks.File            |           7.0.0            |              <https://github.com/serilog/serilog-sinks-file>               |                                                                                                                                      |
|        Serilog.Extensions.Logging        |           9.0.2            |          <https://github.com/serilog/serilog-extensions-logging>           |                                                                                                                                      |
|      Serilog.Settings.Configuration      |           9.0.0            |        <https://github.com/serilog/serilog-settings-configuration>         |                                                                                                                                      |
|         Serilog.Enrichers.Thread         |           4.0.0            |           <https://github.com/serilog/serilog-enrichers-thread>            |                                                                                                                                      |
|             System Reactive              |           6.0.1            |                    <https://github.com/dotnet/reactive>                    |                                                         For throttling only                                                          |
|        Svg.Controls.Skia.Avalonia        |          11.3.0.4          |                <https://github.com/wieslawsoltes/Svg.Skia>                 | All svg icons are from iconify, see <https://icon-sets.iconify.design/material-symbols/> and <https://icon-sets.iconify.design/mdi/> |

## 🔨 Build & Publish

### Windows

```shell
dotnet publish -c Release \
-r win-x64 \
--self-contained true \
-p:PublishSingleFile=true \
-p:IncludeNativeLibrariesForSelfExtract=true \
-p:PublishTrimmed=false \
-p:UseAppHost=true \
-o D:\MyApp\Release\
```

### Linux

```shell
dotnet publish -c Release \
# -r linux-armx64
-r linux-x64 \
--self-contained true \
-p:PublishSingleFile=true \
-p:IncludeNativeLibrariesForSelfExtract=true \
-p:PublishTrimmed=false \
-p:UseAppHost=true \
-o D:\MyApp\Release\
```

## 💪 Contributors

|                                             Shiloh                                              |
|:-----------------------------------------------------------------------------------------------:|
| [![Shiloh](https://avatars.githubusercontent.com/u/46670399?v=4)](https://github.com/shilohooo) |

## 🔖 License

Copyright © 2025-present Shiloh

[MIT](./LICENSE)

