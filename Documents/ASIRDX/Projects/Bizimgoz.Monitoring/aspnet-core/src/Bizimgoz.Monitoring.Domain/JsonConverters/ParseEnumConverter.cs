using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bizimgoz.Monitoring.JsonConverters
{
    public class ParseEnumConverter<T> : JsonConverter<T> where T : Enum
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string stringValue = reader.GetString();
                if (int.TryParse(stringValue, out int parsedValue))
                {
                    if (Enum.IsDefined(typeof(T), parsedValue))
                    {
                        return (T)Enum.ToObject(typeof(T), parsedValue);
                    }
                    else
                    {
                        throw new ArgumentException($"The integer value {parsedValue} does not correspond to any value in the {typeof(T).Name} enum.");
                    }
                }
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                var value = reader.GetInt32();
                if (Enum.IsDefined(typeof(T), value))
                {
                    return (T)Enum.ToObject(typeof(T), value);
                }
                else
                {
                    throw new ArgumentException($"The integer value {value} does not correspond to any value in the {typeof(T).Name} enum.");
                }

            }
            Console.WriteLine(reader.TokenType);
            throw new JsonException("Failed to parse the value.");
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            string stringValue = value.ToString();
            writer.WriteStringValue(stringValue);
        }
    }
}
