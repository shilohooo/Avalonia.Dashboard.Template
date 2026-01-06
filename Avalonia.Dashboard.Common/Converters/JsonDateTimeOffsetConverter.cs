using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Avalonia.Dashboard.Common.Converters;

/// <summary>
///     Custom DateTimeOffset converter
/// </summary>
public sealed class JsonDateTimeOffsetConverter(string format) : JsonConverter<DateTimeOffset>
{
    /// <summary>
    ///     Default format = Year-Month-Day Hour:Minute:Second.Millisecond+TimeZone
    /// </summary>
    private const string DefaultFormat = "yyyy-MM-dd HH:mm:ss.fffzzz";

    /// <summary>
    ///     Format
    /// </summary>
    private readonly string _format = format;

    public JsonDateTimeOffsetConverter() : this(DefaultFormat)
    {
    }

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
