using Newtonsoft.Json;

namespace BoostyLib.Entities;

public class MessageAuthor
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("hasAvatar")]
    public bool HasAvatar { get; set; }

    [JsonProperty("avatarUrl")]
    public Uri AvatarUrl { get; set; }

    [JsonProperty("badges")]
    public List<ChatBadge> Badges { get; set; }

    [JsonProperty("createdAt")]
    public long CreatedAt { get; set; }

    [JsonProperty("isOwner")]
    public bool IsOwner { get; set; }

    [JsonProperty("isChatModerator")]
    public bool IsChatModerator { get; set; }
}
