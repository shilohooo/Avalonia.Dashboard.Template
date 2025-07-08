using System.Text.Json;
using System.Text.Json.Serialization;

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
        Converters = { new JsonStringEnumConverter() }
    };

    /// <summary>
    ///     Deserializes json string to object
    /// </summary>
    /// <param name="jsonStr">json string</param>
    /// <typeparam name="T">object type</typeparam>
    /// <returns>object</returns>
    public static T? Deserialize<T>(string jsonStr)
    {
        return JsonSerializer.Deserialize<T>(jsonStr, DefaultSerializerOptions);
    }
}
