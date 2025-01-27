using Newtonsoft.Json;

namespace BoostyLib.Endpoints.Responses;

public class WebSocketFetchTokenResponse
{
    [JsonProperty("token")]
    public string Token { get; set; }
}
