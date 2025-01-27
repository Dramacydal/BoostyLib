using BoostyLib.Endpoints;

namespace BoostyLib;

public class BoostyApi
{
    private readonly ApiClient _client;

    public Blog Blog { get; }
    
    public VideoStream VideoStream { get; }
    
    public WebSocket WebSocket { get; }

    public BoostyApi(BoostyCredentials credentials)
    {
        _client = new ApiClient(credentials);

        Blog = new(_client);
        VideoStream = new(_client);
        WebSocket = new(_client);
    }
}