using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QrCodeGeneration.Utils
{
    public class EpochConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            long epoch = reader.GetInt64();

            return DateTimeOffset.FromUnixTimeSeconds(epoch).DateTime;
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateTime value,
            JsonSerializerOptions options)
        {
            writer.WriteNumberValue(new DateTimeOffset(value).ToUnixTimeSeconds());
        }
    }
    
    public class NumberToStringConverter : JsonConverter<string>
    {
        public override string Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            return reader.GetInt64().ToString();
        }

        public override void Write(
            Utf8JsonWriter writer,
            string value,
            JsonSerializerOptions options)
        {
            writer.WriteNumberValue(long.Parse(value));
        }
    }
}