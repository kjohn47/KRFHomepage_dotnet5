using System.Text.Json.Serialization;

namespace KRFHomepage.Domain.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum  ResponseErrorType
    {
        Unknown,
        Database,
        Proxy,
        Application
    }
}
