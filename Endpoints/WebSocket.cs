using BoostyLib.Endpoints.Abstraction;
using BoostyLib.Endpoints.Responses;

namespace BoostyLib.Endpoints;

public class WebSocket(ApiClient client) : EndpointBase
{
    public override Endpoint Endpoint => new("/v1/ws");

    public async Task<WebSocketFetchTokenResponse> Fetch()
    {
        return await client.GetAsync<WebSocketFetchTokenResponse>(Endpoint.Build("connect"));
    }
    
    public async Task<WebSocketFetchPrivateTokenResponse> FetchPrivateToken(Guid clientId, List<string> channels)
    {
        try
        {
            return await client.PostAsync<WebSocketFetchPrivateTokenResponse>(Endpoint.Build("subscribe"),
                JsonHelper.Serialize(new
                {
                    client = clientId,
                    channels = channels
                }));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
