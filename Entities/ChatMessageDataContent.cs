using Newtonsoft.Json.Linq;

namespace BoostyLib.Entities;

public class ChatMessageDataContent : List<object>
{
    public ChatMessageDataContent()
    {
    }

    public ChatMessageDataContent(string text, string style = "unstyled")
    {
        base.AddRange([
            text,
            style,
            new JArray()
        ]);
    }

    public string Text
    {
        get => this[0].ToString();
        set => this[0] = value;
    }

    public string UnkStyle
    {
        get => this[1].ToString();
        set => this[1] = value;
    }

    public JArray Unk2
    {
        get => this[2] as JArray;
        set => this[2] = new JValue(value);
    }
}