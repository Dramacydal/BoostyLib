using BoostyLib.Entities.Helpers;
using Newtonsoft.Json;

namespace BoostyLib.Converters;

public class JsonHolderConverter : JsonConverter
{
    public override bool CanRead => true;
    public override bool CanWrite => true;

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        writer.WriteValue((value as AbstractJsonHolder).WriteToString());
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var holder = Activator.CreateInstance(objectType) as AbstractJsonHolder;

        holder.ReadFromString(reader.Value as string);

        return holder;
    }

    public override bool CanConvert(Type objectType)
    {
        return typeof(AbstractJsonHolder).IsAssignableFrom(objectType);
    }
}