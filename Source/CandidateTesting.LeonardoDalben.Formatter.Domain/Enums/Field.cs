using System.ComponentModel;

namespace CandidateTesting.LeonardoDalben.Formatter.Domain.Enums
{
    public enum Field
    {
        [Description("provider")]
        Provider = 1,
        [Description("http-method")]
        HttpMethod = 2,
        [Description("status-code")]
        StatusCode = 3,
        [Description("uri-path")]
        UrlPath = 4,
        [Description("time-taken")]
        TimeTaken = 5,
        [Description("response-size")]
        ResponseSize = 6,
        [Description("cache-status")]
        CacheStatus = 7,
    }
}
