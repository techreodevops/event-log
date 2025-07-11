using Newtonsoft.Json;

namespace EventLog.Middleware.Dtos.Provider.AwsService.Request;

public class TransactionLogDto
{
    [JsonProperty(PropertyName = "_id")]
    public string Id { get; set; }
    [JsonProperty(PropertyName = "logType")]
    public string LogType { get; set; }
    public string Entity { get; set; }
    public string UserId { get; set; }
    public string Application {  get; set; }
    public string IdDevice {  get; set; }
    public string IsToken {  get; set; }
    public string TransactiontType {  get; set; }
    public GeolocationTransactionLogDto Geolocation {  get; set; }
    public TrackingDeviceTransactionLogDto TrackingDevice {  get; set; }
    public Audit Audit { get; set; } = new Audit();
}

public sealed record GeolocationTransactionLogDto(string Latitude, string Longitude);

public sealed record TrackingDeviceTransactionLogDto(string AppVersion, string OsVersion, string Os, string DeviceModel, string DeviceManufacturer);