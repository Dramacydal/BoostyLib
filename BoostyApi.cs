using BoostyLib.Endpoints;

namespace BoostyLib;

public class BoostyApi
{
    private readonly ApiClient _client;

    public readonly BoostyCredentials Credentials;

    public BlogApi BlogApi { get; }

    public TokenApi Token { get; }
    
    public VideoStreamApi VideoStream { get; }

    public WebSocketApi WebSocket { get; }

    public BoostyApi(BoostySettings settings)
    {
        Credentials = settings.Credentials;
        _client = new ApiClient(settings);

        BlogApi = new(_client);
        Token = new (_client);
        VideoStream = new(_client);
        WebSocket = new(_client);
    }
}
