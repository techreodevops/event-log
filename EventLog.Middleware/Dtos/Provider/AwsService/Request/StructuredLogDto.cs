using Newtonsoft.Json;

namespace EventLog.Middleware.Dtos.Provider.AwsService.Request
{
    public class StructuredLogDto
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "logType")]
        public string LogType { get; set; }
        public string Entity { get; set; }
        public string UserId { get; set; }
        public string Application { get; set; }
        public string Severity { get; set; }
        public string Source { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Error { get; set; }
        public Audit Audit { get; set; } = new Audit();
    }
}
