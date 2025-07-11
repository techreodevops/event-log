using Newtonsoft.Json;

namespace EventLog.Middleware.Dtos.Provider.AwsService.Request;

public class MessageLogDto
{
    [JsonProperty(PropertyName = "_id")]
    public string Id { get; set; }
    [JsonProperty(PropertyName = "logType")]
    public string LogType { get; set; }
    public string UserId { get; set; }
    public string Application {  get; set; }
    public string Level {  get; set; }
    public string Method {  get; set; }
    public string Entity { get; set; }
    public string Message {  get; set; }
    public Audit Audit { get; set; } = new Audit();
}
