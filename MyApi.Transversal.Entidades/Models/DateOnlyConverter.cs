using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyApi.Transversal.Entidades
{
    internal class DateOnlyConverter : JsonConverter<DateTime?>
    {
        string _format = "yyyy-MM-dd";
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (DateTime.TryParseExact(reader.GetString(), _format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }
            }
            return null;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                writer.WriteStringValue(value.Value.ToString(_format));
            }
        }
    }
}