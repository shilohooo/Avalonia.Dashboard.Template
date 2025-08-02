using System.Collections.ObjectModel;
using Avalonia.Dashboard.Ui.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace Avalonia.Dashboard.Ui.ViewModels;

/// <summary>
///     主页视图模型
/// </summary>
public partial class HomeViewModel : RecipientViewModelBase, IRecipient<ThemeChangedMessage>
{
    [ObservableProperty] [NotifyPropertyChangedFor(nameof(LegendTextPain))]
    private bool _isDarkMode = true;

    public HomeViewModel()
    {
        InitStarHistorySeries();
    }

    public SolidColorPaint LegendTextPain => IsDarkMode
        ? new SolidColorPaint
        {
            Color = new SKColor(255, 255, 255)
        }
        : new SolidColorPaint
        {
            Color = new SKColor(0, 0, 0)
        };


    /// <summary>
    ///     GitHub repo star history line chart
    /// </summary>
    public ObservableCollection<ISeries> StarHistorySeries { get; set; } = [];

    public ObservableCollection<Axis> StarHistoryXAxes { get; set; } =
    [
        new()
        {
            Labeler = value => (int)value % 2 == 0 ? Math.Round(value).ToString("F0") : string.Empty,
            Name = "Year",
            LabelsPaint = new SolidColorPaint(SKColors.LightGray),
            NamePaint = new SolidColorPaint(SKColors.LightGray)
        }
    ];

    public ObservableCollection<Axis> StarHistoryYAxes { get; set; } =
    [
        new()
        {
            Name = "Stars",
            LabelsPaint = new SolidColorPaint(SKColors.DarkGray),
            NamePaint = new SolidColorPaint(SKColors.LightGray)
        }
    ];

    public ISeries[] MostUsedLanguagesSeries { get; set; } =
    [
        new PieSeries<double> { Values = [30], ToolTipLabelFormatter = ToolTipLabelFormatter, Name = "Java" },
        new PieSeries<double> { Values = [20], ToolTipLabelFormatter = ToolTipLabelFormatter, Name = "JavaScript" },
        new PieSeries<double> { Values = [20], ToolTipLabelFormatter = ToolTipLabelFormatter, Name = "CSharp" },
        new PieSeries<double> { Values = [20], ToolTipLabelFormatter = ToolTipLabelFormatter, Name = "SQL" },
        new PieSeries<double> { Values = [10], ToolTipLabelFormatter = ToolTipLabelFormatter, Name = "Python" }
    ];

    public void Receive(ThemeChangedMessage message)
    {
        IsDarkMode = message.Value;
        
        StarHistoryXAxes.Clear();
        StarHistoryXAxes.Add(new Axis
        {
            Labeler = value => (int)value % 2 == 0 ? Math.Round(value).ToString("F0") : string.Empty,
            Name = "Year",
            LabelsPaint = new SolidColorPaint(IsDarkMode ? SKColors.LightGray : SKColors.Black),
            NamePaint = new SolidColorPaint(IsDarkMode ? SKColors.LightGray : SKColors.Black)
        });
        
        StarHistoryYAxes.Clear();
        StarHistoryYAxes.Add(new Axis
        {
            Name = "Stars",
            LabelsPaint = new SolidColorPaint(IsDarkMode ? SKColors.LightGray : SKColors.Black),
            NamePaint = new SolidColorPaint(IsDarkMode ? SKColors.LightGray : SKColors.Black)
        });
    }

    private void InitStarHistorySeries()
    {
        StarHistorySeries =
        [
            new LineSeries<ObservablePoint>
            {
                // Values = [0, 12, 56, 280, 1000, 1200, 2000, 3000],
                Values =
                [
                    new ObservablePoint(2014, 56),
                    new ObservablePoint(2016, 280),
                    new ObservablePoint(2018, 1000),
                    new ObservablePoint(2020, 1200),
                    new ObservablePoint(2022, 2000),
                    new ObservablePoint(2024, 3000)
                ],
                Name = "Redis",
                Stroke = new SolidColorPaint(SKColors.Orange, 2),
                Fill = null
            },
            new LineSeries<ObservablePoint>
            {
                // Values = [0, 6, 100, 200, 360, 1200, 1600, 2600],
                Values =
                [
                    new ObservablePoint(2014, 100),
                    new ObservablePoint(2016, 200),
                    new ObservablePoint(2018, 360),
                    new ObservablePoint(2020, 1200),
                    new ObservablePoint(2022, 1600),
                    new ObservablePoint(2024, 2600)
                ],
                Name = "Garnet",
                Stroke = new SolidColorPaint(SKColors.SkyBlue, 2),
                Fill = null
            }
        ];
    }

    private static string ToolTipLabelFormatter(ChartPoint<double, DoughnutGeometry, LabelGeometry> arg)
    {
        return $"{arg.Model / 100.0d * 100:0.00}%";
    }
}
