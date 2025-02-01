using BoostyLib.Endpoints.Abstraction;
using BoostyLib.Endpoints.Responses;
using BoostyLib.Entities;

namespace BoostyLib.Endpoints;

public class VideoStreamApi(ApiClient client) : EndpointBase
{
    public override Endpoint Endpoint => new("/v1/blog/{channelName}/video_stream");

    public async Task<VideoStreamResponse?> Get(string channelName)
    {
        return await client.GetAsync<VideoStreamResponse>(Endpoint.Build("", new()
        {
            ["channelName"] = channelName,
        }));
    }
    
    public async Task<ChatResponse?> GetChat(string channelName, int limit = 10)
    {
        if (limit <= 0)
            limit = 10;

        return await client.GetAsync<ChatResponse>(Endpoint.Build("chat", new()
        {
            ["channelName"] = channelName,
        }), new()
        {
            new("limit", limit.ToString())
        });
    }

    public async Task SendMessage(string channelName, string message)
    {
        var data = ChatMessage.CreateBasicMessage(message);

        await client.PostAsync<object>(this.Endpoint.Build("chat", new()
        {
            ["channelName"] = channelName,
        }), formData: new()
        {
            new("data", JsonHelper.Serialize(data))
        });
        return;
    }
}