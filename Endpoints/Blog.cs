using BoostyLib.Endpoints.Abstraction;
using BoostyLib.Endpoints.Responses;

namespace BoostyLib.Endpoints;

public class Blog(ApiClient client) : EndpointBase
{
    public override Endpoint Endpoint => new("/v1/blog/{channelName}");

    public async Task<BlogResponse?> Get(string channelName)
    {
        return await client.GetAsync<BlogResponse>(Endpoint.Build("", new()
        {
            ["channelName"] = channelName,
        }));
    }
}