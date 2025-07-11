using Newtonsoft.Json;

namespace EventLog.Middleware.Dtos.Provider.AwsService.Request
{
    public class ProviderLogDto
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "logType")]
        public string LogType { get; set; }
        public string UserId { get; set; }
        public string Provider { get; set; }
        public string Method { get; set; }
        public string Entity { get; set; }
        public string Url { get; set; }
        public object Headers { get; set; }
        public object Request { get; set; }
        public object Response { get; set; }
        public string StatusCode { get; set; }
        public bool IsError { get; set; }
        public Audit Audit { get; set; } = new Audit();
    }
}
