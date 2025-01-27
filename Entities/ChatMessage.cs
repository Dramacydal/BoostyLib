using BoostyLib.Entities.Helpers;
using Newtonsoft.Json;

namespace BoostyLib.Entities;

public class ChatMessage
{
    [JsonProperty("id")]
    public long Id { get; set; }
    
    [JsonProperty("author")]
    public MessageAuthor Auhor { get; set; }
    
    [JsonProperty("data")]
    public List<ChatMessageData> Data { get; set; }
    
    [JsonProperty("isPrivate")]
    public bool IsPrivate { get; set; }
    
    [JsonProperty("styles")]
    public List<object> Styles { get; set; }
    
    [JsonProperty("createdAt")]
    public long CreatedAt { get; set; }

    public static List<ChatMessageData> CreateBasicMessage(string text)
    {
        return
        [
            new()
            {
                Type = "text",
                Modififactor = "",
                Content = new JsonHolder<ChatMessageDataContent>(new(text))
            },
            new()
            {
                Type = "BLOCK_END",
                Modififactor = "",
                Content = null,
            },
            new()
            {
                Type = "BLOCK_END",
                Modififactor = "",
                Content = null,
            },
        ];
    }
}