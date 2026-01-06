using System.Text.Json;
using System.Text.Json.Serialization;
using Avalonia.Dashboard.Common.Converters;

namespace Avalonia.Dashboard.Common.Helpers;

/// <summary>
///     Json serialization & deserialization helper
/// </summary>
public static class JsonHelper
{
    private static readonly JsonSerializerOptions DefaultSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter(), new JsonDateTimeOffsetConverter() }
    };

    /// <summary>
    ///     Deserializes JSON string to object
    /// </summary>
    /// <param name="jsonStr">JSON string</param>
    /// <typeparam name="T">object type</typeparam>
    /// <returns>object</returns>
    public static T? Deserialize<T>(string jsonStr)
    {
        return JsonSerializer.Deserialize<T>(jsonStr, DefaultSerializerOptions);
    }

    /// <summary>
    ///     Deserializes JSON string to object with specified options
    /// </summary>
    /// <param name="jsonStr">JSON string</param>
    /// <param name="options">JSON serializer options</param>
    /// <typeparam name="T">object type</typeparam>
    /// <returns>object</returns>
    public static T? Deserialize<T>(string jsonStr, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<T>(jsonStr, options);
    }
}
