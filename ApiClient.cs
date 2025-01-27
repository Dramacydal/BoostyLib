using System.Net;
using System.Text;
using System.Web;
using BoostyLib.Exceptions;
using Newtonsoft.Json.Linq;

namespace BoostyLib;

public class ApiClient
{
    private readonly BoostyCredentials _credentials;
    
    internal ApiClient(BoostyCredentials credentials)
    {
        _credentials = credentials;
    }

    private Uri MakeUri(string endpoint, List<KeyValuePair<string, string>>? parameters)
    {
        var uri = new Uri($"https://api.boosty.to" + endpoint);

        var query = HttpUtility.ParseQueryString(string.Empty);
        if (parameters != null)
            foreach (var item in parameters)
                query.Add(item.Key, item.Value);


        var b = new UriBuilder(uri);
        b.Query = query.ToString();

        return b.Uri;
    }

    public async Task<object?> GetAsync(string url, List<KeyValuePair<string,string>>? parameters = null)
    {
        var uri = MakeUri(url, parameters);

        var client = new HttpClient();

        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_credentials.AccessToken}");

        var res = await client.GetAsync(uri);
        switch (res.StatusCode)
        {
            case HttpStatusCode.OK:
                break;
            case HttpStatusCode.NoContent:
                return null;
            case HttpStatusCode.Unauthorized:
                throw new BoostyUnauthorizedException();
            case HttpStatusCode.NotFound:
                throw new BoostyNotFoundException();
            default:
                throw new BoostyException($"Got unexpected status code {res.StatusCode}");
        }
        
        var str = res.Content.ReadAsStringAsync().Result;
        if (string.IsNullOrEmpty(str))
            return null;
        
        return JsonHelper.Deserialize(str);
    }

    public async Task<T?> GetAsync<T>(string url, List<KeyValuePair<string, string>>? parameters = null)
    {
        var obj = await GetAsync(url, parameters);
        if (obj == null)
            return default;

        return JsonHelper.ToObject<T>((JToken)obj);
    }

    public async Task<T?> PostAsync<T>(string url, string? payload = null, List<KeyValuePair<string, string>>? formData = null)
    {
        if (!string.IsNullOrEmpty(payload) && formData != null)
            throw new Exception("Exclusively payload or formData must be specified");

        HttpContent? content = null;
        if (formData != null)
            content = new FormUrlEncodedContent(formData);
        else if (!string.IsNullOrEmpty(payload))
            content = new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded");

        var response = await _PostAsync(url, content);
        
        var str = response.Content.ReadAsStringAsync().Result;
        if (string.IsNullOrEmpty(str))
            return default;
        
        return JsonHelper.Deserialize<T>(str);
    }

    private async Task<HttpResponseMessage> _PostAsync(string url, HttpContent? content)
    {
        var uri = MakeUri(url, []);

        var client = new HttpClient();

        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_credentials.AccessToken}");

        var res = await client.PostAsync(uri, content);
        switch (res.StatusCode)
        {
            case HttpStatusCode.OK:
                break;
            case HttpStatusCode.Unauthorized:
                throw new BoostyUnauthorizedException();
            case HttpStatusCode.NoContent:
                throw new BoostyNoContentException();
            case HttpStatusCode.NotFound:
                throw new BoostyNotFoundException();
            default:
                throw new BoostyException($"Got unexpected status code {res.StatusCode}");
        }

        return res;
    }
}