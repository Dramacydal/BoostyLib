using Newtonsoft.Json;

namespace BoostyLib.Entities;

public class ChatExtra
{
    [JsonProperty("isLast")]
    public bool IsLast { get; set; }
    
    [JsonProperty("isBaned")]
    public bool IsBanned { get; set; }
    
    [JsonProperty("offset")]
    public long Offset { get; set; }
}