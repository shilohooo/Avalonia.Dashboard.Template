using System.Text.Json.Serialization;
using Avalonia.Dashboard.Common.Converters;
using Avalonia.Dashboard.Domains.Enums;
using Avalonia.Dashboard.Domains.Models;

namespace Avalonia.Dashboard.Domains;

[JsonSourceGenerationOptions(WriteIndented = true,
    PropertyNameCaseInsensitive = true,
    Converters =
    [
        typeof(JsonDateTimeOffsetConverter),
        // Define converter for each enums
        typeof(JsonStringEnumConverter<ViewName>)
    ],
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(MenuItem))]
[JsonSerializable(typeof(List<MenuItem>))]
[JsonSerializable(typeof(ActivityLog))]
[JsonSerializable(typeof(List<ActivityLog>))]
public partial class AppJsonSerializerContext : JsonSerializerContext
{
}
