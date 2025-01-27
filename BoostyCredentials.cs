using Newtonsoft.Json;

namespace BoostyLib;

public class BoostyCredentials
{
    [JsonProperty("device_id")]
    public string DeviceId { get; set; }
    
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }
    
    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }
    
    [JsonProperty("expires_at")]
    public long? ExpiresAt { get; set; }
}