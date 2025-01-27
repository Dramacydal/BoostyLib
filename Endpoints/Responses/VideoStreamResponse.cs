using Newtonsoft.Json;

namespace BoostyLib.Endpoints.Responses;

public class VideoStreamResponse
{
    [JsonProperty("isDeleted")]
    public bool IsDeleted { get; set; }

    [JsonProperty("startTime")]
    public int StartTime { get; set; }

    [JsonProperty("isChatModerator")]
    public bool IsChatModerator { get; set; }

    [JsonProperty("chatSettings")]
    public ChatSettings ChatSettings { get; set; }

    [JsonProperty("wsChatChannel")]
    public string WsChatChannel { get; set; }

    [JsonProperty("description")]
    public List<object> Description { get; set; }

    [JsonProperty("data")]
    public List<VideoStreamData> VideoStreamData { get; set; }

    [JsonProperty("int_id")]
    public int IntId { get; set; }

    [JsonProperty("isTemplate")]
    public bool IsTemplate { get; set; }
    
    [JsonProperty("isLiked")]
    public bool IsLiked { get; set; }
    
    [JsonProperty("subscriptionLevel")]
    public SubscriptionLevel SubscriptionLevel { get; set; }

    [JsonProperty("isOnline")]
    public bool IsOnline { get; set; }

    [JsonProperty("count")]
    public StreamCounts Count { get; set; }

    [JsonProperty("price")]
    public long Price { get; set; }

    [JsonProperty("hasChat")]
    public bool HasChat { get; set; }

    [JsonProperty("user")]
    public User User { get; set; }

    [JsonProperty("sortOrder")]
    public int SortOrder { get; set; }

    [JsonProperty("daNick")]
    public string DaNick { get; set; }

    [JsonProperty("createdAt")]
    public int CreatedAt { get; set; }

    [JsonProperty("signedQuery")]
    public string SignedQuery { get; set; }

    [JsonProperty("teaser")]
    public List<object> Teaser { get; set; }

    [JsonProperty("wsStreamViewersChannel")]
    public string WsStreamViewersChannel { get; set; }

    [JsonProperty("wsChatChannelPrivate")]
    public string WsChatChannelPrivate { get; set; }

    [JsonProperty("publishTime")]
    public int PublishTime { get; set; }

    [JsonProperty("wsStreamChannel")]
    public string WsStreamChannel { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("hasAccess")]
    public bool HasAccess { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }
}

public class User
{
    [JsonProperty("hasAvatar")]
    public bool HasAvatar { get; set; }
    
    [JsonProperty("avatarUrl")]
    public Uri AvatarUrl { get; set; }
    
    [JsonProperty("blogUrl")]
    public string BlogUrl { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("flags")]
    public UserFlags Flags { get; set; }
    
    [JsonProperty("id")]
    public long Id { get; set; }
}

public class UserFlags
{
    [JsonProperty("showPostDonations")]
    public bool ShowPostDonations { get; set; }
}

public class StreamCounts
{
    [JsonProperty("likes")]
    public int Likes { get; set; }
    
    [JsonProperty("viewers")]
    public int Viewers { get; set; }
}

public class SubscriptionLevel
{
    [JsonProperty("createdAt")]
    public int CreatedAt { get; set; }
    
    [JsonProperty("isArchived")]
    public bool IsArchived { get; set; }
    
    [JsonProperty("isLimited")]
    public bool IsLimited { get; set; }
    
    [JsonProperty("currencyPrices")]
    public Dictionary<string, double> CurrencyPrices { get; set; }
    
    [JsonProperty("ownerId")]
    public long OwnerId { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("deleted")]
    public bool Deleted { get; set; }
    
    [JsonProperty("price")]
    public long Price { get; set; }
    
    [JsonProperty("id")]
    public long Id { get; set; }
    
    [JsonProperty("data")]
    public List<object> Data { get; set; }
    
    [JsonProperty("isHidden")]
    public bool IsHidden { get; set; }
}

public class VideoStreamData
{
    [JsonProperty("type")]
    public string Type { get; set; }
    
    [JsonProperty("failoverHost")]
    public string FailoverHost { get; set; }
    
    [JsonProperty("title")]
    public string Title { get; set; }
    
    [JsonProperty("vid")]
    public string Vid { get; set; }
    
    [JsonProperty("playerUrls")]
    public List<PlayerUrl> PlayerUrls { get; set; }
}

public class PlayerUrl
{
    [JsonProperty("type")]
    public string Type { get; set; }
    
    [JsonProperty("url")]
    public string Url { get; set; }
}

public class ChatSettings
{
    [JsonProperty("sameMessageTimeout")]
    public int SameMessageTimeout { get; set; }
    
    [JsonProperty("anyMessageTimeout")]
    public int AnyMessageTimeOut { get; set; }
}
