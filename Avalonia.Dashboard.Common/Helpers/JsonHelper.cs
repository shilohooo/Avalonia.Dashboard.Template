using System.Globalization;
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
        Converters = { new JsonStringEnumConverter(), new JsonDateTimeOffsetConverter() }
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

/// <summary>
///     Custom DateTimeOffset converter
/// </summary>
public sealed class JsonDateTimeOffsetConverter(string format = JsonDateTimeOffsetConverter.DefaultFormat)
    : JsonConverter<DateTimeOffset>
{
    /// <summary>
    ///     Default format
    /// </summary>
    private const string DefaultFormat = "yyyy-MM-dd HH:mm:ss";

    /// <summary>
    ///     Format
    /// </summary>
    private readonly string _format = format;

    /// <inheritdoc />
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType is not JsonTokenType.String)
            throw new JsonException($"Unexpected token type. Expected {JsonTokenType.String}, got {reader.TokenType}");

        return DateTimeOffset.TryParseExact(
            reader.GetString(),
            _format,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out var result
        )
            ? result
            : throw new JsonException(
                $"Unable to parse date time offset with format {_format} from {reader.GetString()}");
    }


    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}
