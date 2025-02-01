using BoostyLib.Endpoints.Abstraction;
using BoostyLib.Endpoints.Responses;

namespace BoostyLib.Endpoints;

public class TokenApi(ApiClient client) : EndpointBase
{
    public override Endpoint Endpoint => new("/oauth");

    public async Task<TokenRefreshResponse> Refresh(string refreshToken, string deviceId, string os = "web")
    {
        return await client.PostAsync<TokenRefreshResponse>(Endpoint.Build("token/"), // "/" is mandatory
            formData: new()
            {
                new("device_id", deviceId),
                new("grant_type", "refresh_token"),
                new("refresh_token", refreshToken),
                new("device_os", os),
            });
    }
}