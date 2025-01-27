using BoostyLib.Entities;
using Newtonsoft.Json;

namespace BoostyLib.Endpoints.Responses;

public class ChatResponse
{
    [JsonProperty("data")]
    public List<ChatMessage> Data { get; set; }
    
    [JsonProperty("extra")]
    public ChatExtra Extra { get; set; }
}