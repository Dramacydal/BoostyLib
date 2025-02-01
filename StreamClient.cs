using System.Net.WebSockets;
using BoostyLib.Endpoints.Responses;
using BoostyLib.Entities;
using BoostyLib.Exceptions;
using Centrifugo.Client.Json;
using Centrifugo.Client.Json.Enums;
using Centrifugo.Client.Json.Events;
using Centrifugo.Client.Json.Protocol.PushTypes;
using NLog;
using Websocket.Client;
using Subscription = Centrifugo.Client.Json.Subscription;

namespace BoostyLib;

public class StreamClient
{
    private readonly BoostyCredentials _credentials;
    
    public readonly string ChannelName;
    
    public readonly BoostyApi Api;
    
    private readonly ILogger? _logger;
    
    private BlogResponse _blog;

    private List<Subscription> _subscriptions = new();

    private Subscription CreateSubscription(string channelName)
    {
        var s = new Subscription(channelName);
        _subscriptions.Add(s);
        return s;
    }

    public StreamClient(string channelName, BoostyCredentials credentials, ILogger? logger = null)
    {
        ChannelName = channelName;
        _credentials = credentials;
        _logger = logger;
        
        Api = new BoostyApi(_credentials);
    }

    private VideoStreamResponse? _stream;

    private CancellationTokenSource _tokenSource = new();
    private CentrifugoClient _centrifugo;
    private Guid _clientId;

    public delegate void ConnectedEventHandler();
    public event ConnectedEventHandler? OnConnected;
    
    public delegate void StreamStartedEventHandler();
    public event StreamStartedEventHandler? OnStreamStarted;
    
    public delegate void StreamEndedEventHandler();
    public event StreamEndedEventHandler? OnStreamEnded;
    
    public delegate void MessageReceivedEventHandler(ChatMessage message);
    public event MessageReceivedEventHandler? OnMessageReceived;

    public delegate void ErrorEventHandler(ErrorEvent error);
    public event ErrorEventHandler? OnError;
    
    public async Task Connect()
    {
        _blog = await Api.Blog.Get(ChannelName);
        _stream = await Api.VideoStream.Get(ChannelName);
        if (_stream == null)
            throw new BoostyException("Stream is offline");

        var webSocketInfo = await Api.WebSocket.Fetch();
        if (webSocketInfo == null)
            throw new BoostyException("Failed to fetch websocket info");

        var ws = new WebsocketClient(new Uri("wss://pubsub.boosty.to/connection/websocket"), clientFactory: () =>
        {
            var sock = new ClientWebSocket();
            sock.Options.SetRequestHeader("origin", "https://boosty.to");
            return sock;
        });

        // create client
        _centrifugo = new CentrifugoClient(new() { WebsocketClient = ws, PingMethod = PingMethod.ClientOnly });

        _centrifugo.SetToken(webSocketInfo.Token);
        _centrifugo.SetName("js");

        _centrifugo.OnConnect(async e =>
        {
            try
            {
                _clientId = Guid.Parse(e.Data.Client);
                OnConnected?.Invoke();

                await Subscribe();
            }
            catch (Exception ex)
            {
                _logger?.Error($"Failed to subscribe after connection, {ex.GetType()}: {ex.Message}");
            }
        });

        _centrifugo.OnMessage(@event =>
        {
            try
            {
                _logger?.Debug("Received broadcast message:");
                _logger?.Debug(@event.Data.Data.ToString());
            }
            catch (Exception ex)
            {
                _logger?.Error($"Failed to process message, {ex.GetType()}: {ex.Message}");
            }
        });

        _centrifugo.OnError(@event =>
        {
            try
            {
                if (@event.Exception != null)
                    _logger?.Error(
                        $"Received centrifugo exception, {@event.Exception.GetType()}: {@event.Exception.Message}");
                else
                    _logger?.Error($"Received centrifugo error, {@event.Data.Code}: {@event.Data.Message}");
                
                OnError?.Invoke(@event);
                
            }
            catch (Exception ex)
            {
                _logger?.Error($"Failed to process error, {ex.GetType()}: {ex.Message}");
            }
        });

        await _centrifugo.ConnectAsync(_tokenSource.Token);
    }

    private async Task Subscribe()
    {
        if (_stream == null)
            _stream = await Api.VideoStream.Get(ChannelName);

        if (_stream == null)
            return;

        foreach (var s in _subscriptions)
        {
            if (s.State == SubscriptionState.Subscribed)
            {
                _logger?.Debug($"Unsubscribing from {s.Channel}...");
                await _centrifugo.UnsubscribeAsync(s.Channel);
            }
        }

        _subscriptions.Clear();

        var callback = async (PushEvent<Publication> e) =>
        {
            try
            {
                await OnSubscriptionPublication(e.Data);
            }
            catch (Exception ex)
            {
                _logger?.Error($"{ex.GetType()}: {ex.Message}");
            }
        };

        var privateTokenResponse =
            await Api.WebSocket.FetchPrivateToken(_clientId, [_stream.WsStreamChannel, _stream.WsChatChannel]);
        foreach (var channel in privateTokenResponse.Channels)
        {
            var sub = CreateSubscription(channel.Channel);
            sub.OnPublicationPush(callback);
            await _centrifugo.SubscribeAsync(sub, channel.Token);
        }
    }

    private async Task OnSubscriptionPublication(Publication publication)
    {
        _logger?.Debug($"Received subscription message for channel {publication.Channel}: {publication.Data}");

        if (publication.Data.TryGetValue("type", out var messageType))
        {
            switch (messageType.ToString())
            {
                case "stream_end":
                    _logger?.Debug("Stream ended");
                    _stream = null;
                    OnStreamEnded?.Invoke();
                    break;
                case "stream_start":
                    OnStreamStarted?.Invoke();
                    _logger?.Debug("Stream started, resubscribing");
                    await Subscribe();
                    return;
                case "stream_online_status":
                    return;
                case "message":
                    var message = JsonHelper.ToObject<ChatMessage>(publication.Data["data"]);

                    OnMessageReceived?.Invoke(message);
                    return;
            }
        }
    }

    public async Task RefreshToken()
    {
        throw new NotImplementedException();
    }

    public async Task SendMessage(string message)
    {
        await Api.VideoStream.SendMessage(ChannelName, message);
    }
}