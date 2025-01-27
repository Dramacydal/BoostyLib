using BoostyLib.Entities.Helpers;
using Newtonsoft.Json;

namespace BoostyLib.Entities;

public class ChatMessageData
{
    [JsonProperty("content")]
    public JsonHolder<ChatMessageDataContent> Content { get; set; }
    
    [JsonProperty("modificator")]
    public string Modififactor { get; set; }
    
    [JsonProperty("type")]
    public string Type { get; set; }
}