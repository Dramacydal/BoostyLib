using Newtonsoft.Json;

namespace BoostyLib.Endpoints.Responses;

public class WebSocketFetchPrivateTokenResponse
{
    public class ChannelToken
    {
        public string Token { get; set; }
        public string Channel { get; set; }
    }

    [JsonProperty("channels")]
    public List<ChannelToken> Channels { get; set; }
}
