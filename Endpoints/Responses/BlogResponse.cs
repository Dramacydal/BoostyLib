using Newtonsoft.Json;

namespace BoostyLib.Endpoints.Responses;

public class BlogResponse
{
    [JsonProperty("owner")]
    public Owner Owner { get; set; }
    
    [JsonProperty("signedQuery")]
    public string SignedQuery { get; set; }
    
    [JsonProperty("accessRights")]
    public AccessRights AccessRights { get; set; }
    
    [JsonProperty("isReadOnly")]
    public bool IsReadOnly { get; set; }
    
    [JsonProperty("count")]
    public BlogCounts Count { get; set; }
    
    [JsonProperty("subscriptionKind")]
    public string SubscriptionKind { get; set; }
    
    [JsonProperty("isTotalBaned")]
    public bool IsTotalBanned { get; set; }
    
    [JsonProperty("coverUrl")]
    public string CoverUrl { get; set; }
    
    [JsonProperty("subscription")]
    public Subscription Subscription { get; set; }
    
    [JsonProperty("socialLinks")]
    public List<SocialLink> SocialLinks { get; set; }
    
    [JsonProperty("description")]
    public List<object> Description { get; set; }
    
    [JsonProperty("title")]
    public string Title { get; set; }
    
    [JsonProperty("allowedPromoTypes")]
    public List<string> AllowedPromoTypes { get; set; }
    
    [JsonProperty("flags")]
    public BlogFlags Flags { get; set; }
    
    [JsonProperty("isOwner")]
    public bool IsOwner { get; set; }
    
    [JsonProperty("isBlackListedByUser")]
    public bool IsBlackListedByUser { get; set; }
    
    [JsonProperty("publicWebSocketChannel")]
    public string PublicWebSocketChannel { get; set; }
    
    [JsonProperty("hasAdultContent")]
    public bool HasAdultContent { get; set; }
    
    [JsonProperty("isBlackListed")]
    public bool IsBlackListed { get; set; }
    
    [JsonProperty("isSubscribed")]
    public bool IsSubscribed { get; set; }
    
    [JsonProperty("blogUrl")]
    public string BlogUrl { get; set; }
}

public class Owner
{
    [JsonProperty("avatarUrl")]
    public string AvatarUrl { get; set; }
    
    [JsonProperty("id")]
    public long Id { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("hasAvatar")]
    public bool HasAvatar { get; set; }
    
    [JsonProperty("externalApps")]
    public Dictionary<string, ExternalApp> ExternalApps { get; set; }// TODO: actually a struct with custom serialization
}

public class BlogFlags
{
    [JsonProperty("isVerifyPayoutBlocked")]
    public bool IsVerifyPayoutBlocked { get; set; }
    
    [JsonProperty("showPostDonations")]
    public bool ShowPostDonations { get; set; }
    
    [JsonProperty("acceptDonationMessages")]
    public bool AcceptDonationMessages { get; set; }
    
    [JsonProperty("hasTargets")]
    public bool HasTargets { get; set; }
    
    [JsonProperty("isPayoutBlocked")]
    public bool IsPayoutBlocked { get; set; }
    
    [JsonProperty("hasSubscriptionLevels")]
    public bool HasSubscriptionLevels { get; set; }
    
    [JsonProperty("hasAdultContent")]
    public bool HasAdultContent { get; set; }
    
    [JsonProperty("forbiddenChangeHasAdultContent")]
    public bool ForbiddenChangeHasAdultContent { get; set; }
    
    [JsonProperty("allowGoogleIndex")]
    public bool AllowGoogleIndex { get; set; }
    
    [JsonProperty("allowIndex")]
    public bool AllowIndex { get; set; }
    
    [JsonProperty("isRssFeedEnabled")]
    public bool IsRssFeedEnabled { get; set; }
    
    [JsonProperty("isPaymentAcceptBlocked")]
    public bool IsPaymentAcceptBlocked { get; set; }
}

public class SocialLink
{
    [JsonProperty("url")]
    public Uri Url { get; set; }
    
    [JsonProperty("type")]
    public string Type { get; set; }
}

public class Subscription
{
    [JsonProperty("id")]
    public long Id { get; set; }
    
    [JsonProperty("customPrice")]
    public long CustomPrice { get; set; }
    
    [JsonProperty("period")]
    public int Period { get; set; }
    
    [JsonProperty("onTime")]
    public int OnTime { get; set; }
    
    [JsonProperty("isApplePayed")]
    public bool IsApplePayed { get; set; }
    
    [JsonProperty("offTime")]
    public int? OffTime { get; set; }
    
    [JsonProperty("levelId")]
    public int LevelId { get; set; }
}

public class BlogCounts
{
    [JsonProperty("posts")]
    public int Posts { get; set; }
    
    [JsonProperty("subscribers")]
    public int Subscribers { get; set; }
}

public class AccessRights
{
    [JsonProperty("canCreateComments")]
    public bool CanCreateComments { get; set; }
    
    [JsonProperty("canSetPayout")]
    public bool CanSetPayout { get; set; }
    
    [JsonProperty("canEdit")]
    public bool CanEdit { get; set; }
    
    [JsonProperty("canDeleteComments")]
    public bool CanDeleteComments { get; set; }
    
    [JsonProperty("canView")]
    public bool CanView { get; set; }
    
    [JsonProperty("canCreate")]
    public bool CanCreate { get; set; }
}

public class ExternalApp
{
    [JsonProperty("username")]
    public string UserName { get; set; }
    
    [JsonProperty("hasServer")]
    public bool HasServer { get; set; }
    
    [JsonProperty("serverName")]
    public string ServerName { get; set; }
    
    [JsonProperty("hasAccount")]
    public bool HasAccount { get; set; }
}