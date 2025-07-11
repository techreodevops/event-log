namespace EventLog.Middleware.Dtos.Common.Request;

public sealed record TransactionLogReqDto(
    string ProviderId,
    string UserId,
    string Entity,
    string Application,
    string IdDevice,
    string TransactionType,
    string IsToken,
    Geolocation Geolocation,
    TrackingDevice TrackingDevice
);

public sealed record Geolocation(string Latitude, string Longitude);

public sealed record TrackingDevice(string AppVersion, string OsVersion, string Os, string DeviceModel, string DeviceManufacturer);
