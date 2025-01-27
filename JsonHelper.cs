using BoostyLib.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BoostyLib;

public static class JsonHelper
{
    private static readonly JsonSerializer _serializer;
    private static readonly JsonSerializerSettings _settings;

    static JsonHelper()
    {
        _settings = new JsonSerializerSettings();
        _settings.Formatting = Formatting.None;
        _settings.Converters.Add(new JsonHolderConverter());
        // _settings.TypeNameHandling = TypeNameHandling.Auto;

        _serializer = new JsonSerializer()
        {
            Formatting = Formatting.None,
        };

        foreach (var c in _settings.Converters)
            _serializer.Converters.Add(c);
    }

    public static T? ToObject<T>(JToken value)
    {
        return value.ToObject<T>(_serializer);
    }

    public static object? Deserialize(string value)
    {
        return JsonConvert.DeserializeObject(value, _settings);
    }
    
    public static T? Deserialize<T>(string value)
    {
        return JsonConvert.DeserializeObject<T>(value, _settings);
    }

    public static string Serialize(object obj)
    {
        return JsonConvert.SerializeObject(obj, _settings);
    }
}
