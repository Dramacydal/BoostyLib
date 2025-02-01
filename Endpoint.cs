using System.Text.RegularExpressions;

namespace BoostyLib;

public class Endpoint
{
    public string _value;

    public Endpoint(string value)
    {
        _value = value;
    }

    public string Build(string suffix = "", Dictionary<string, string>? parameters = null)
    {
        suffix = suffix.TrimStart('/');
        if (!string.IsNullOrEmpty(suffix))
            suffix = "/" + suffix;

        var endpoint = "/" + _value.Trim('/') + suffix;

        if (parameters != null)
        {
            endpoint = Regex.Replace(endpoint, @"\{([a-z]+)\}", e =>
            {
                if (parameters.TryGetValue(e.Groups[1].Value, out var value))
                    return value;

                return e.Groups[1].Value;
            }, RegexOptions.IgnoreCase);
        }

        return endpoint;
    }
}