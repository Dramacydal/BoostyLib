namespace BoostyLib;

public class BoostySettings
{
    public BoostyCredentials Credentials { get; set; }
    
    public Dictionary<string, string>? Headers { get; set; }

    public Func<HttpClient>? HttpClientFactory { get; set; }
}
