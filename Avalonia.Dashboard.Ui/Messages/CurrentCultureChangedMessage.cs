using System.Globalization;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Avalonia.Dashboard.Ui.Messages;

/// <summary>
/// 
/// </summary>
public class CurrentCultureChangedMessage(CultureInfo cultureInfo) : ValueChangedMessage<CultureInfo>(cultureInfo);