using Newtonsoft.Json;

namespace EventLog.Middleware.Dtos.Provider.AwsService
{
    public class MainDto
    {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "logType")]
        public string LogType { get; set; }
        public string UserId { get; set; }
        public string Entity { get; set; }
        public Audit Audit { get; set; } = new Audit();
    }
}
