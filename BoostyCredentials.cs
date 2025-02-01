using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace BoostyLib;

public class BoostyCredentials : INotifyPropertyChanged
{
    private string _deviceId;
    private string _accessToken;
    private string _refreshToken;
    private long? _expiresAt;

    [JsonProperty("device_id")]
    public string DeviceId
    {
        get => _deviceId;
        set
        {
            if (_deviceId == value)
                return;
            
            _deviceId = value;
            OnPropertyChanged();
        }
    }

    [JsonProperty("access_token")]
    public string AccessToken
    {
        get => _accessToken;
        set
        {
            if (_accessToken == value)
                return;
            
            _accessToken = value;
            OnPropertyChanged();
        }
    }

    [JsonProperty("refresh_token")]
    public string RefreshToken
    {
        get => _refreshToken;
        set
        {
            if (_refreshToken == value)
                return;
            
            _refreshToken = value;
            OnPropertyChanged();
        }
    }

    [JsonProperty("expires_at")]
    public long? ExpiresAt
    {
        get => _expiresAt;
        set
        {
            if (_expiresAt == value)
                return;
            
            _expiresAt = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
