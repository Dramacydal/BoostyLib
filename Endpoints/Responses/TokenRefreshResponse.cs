using Newtonsoft.Json;

namespace BoostyLib.Endpoints.Responses;

public class TokenRefreshResponse
{
    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }
}
