namespace BoostyLib.Entities.Helpers;

public class JsonHolder<T> : AbstractJsonHolder
{
    public T? Value { get; set; }

    public JsonHolder()
    {
    }
    
    public JsonHolder(T value)
    {
        Value = value;
    }
    
    public override void ReadFromString(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            Value = default;
            return;
        }

        Value = JsonHelper.Deserialize<T>(value);
    }

    public override string WriteToString()
    {
        if (Value == null)
            return "";
        
        var str = JsonHelper.Serialize(Value);

        return str;
    }
}