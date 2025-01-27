using Newtonsoft.Json;

namespace BoostyLib.Entities;

public class ChatBadge
{
    public class BadgeAchievement
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("isCreated")]
    public bool IsCreated { get; set; }
    
    [JsonProperty("achievement")]
    public BadgeAchievement Achievement { get; set; }

    [JsonProperty("smallUrl")]
    public Uri SmallUrl { get; set; }
    
    [JsonProperty("mediumUrl")]
    public Uri MediumUrl { get; set; }
    
    [JsonProperty("largeUrl")]
    public Uri LargeUrl { get; set; }

}