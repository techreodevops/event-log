namespace EventLog.Middleware.Dtos.Common.Request;

public sealed record TransactionLogReqDto(
    string ProviderId,
    string UserId,
    string Entity,
    string Application,
    string IdDevice,
    string TransactionType,
    string IsToken,
    GeolocationReqDto Geolocation,
    TrackingDeviceReqDto TrackingDevice
);

public sealed record GeolocationReqDto(string Latitude, string Longitude);

public sealed record TrackingDeviceReqDto(string AppVersion, string OsVersion, string Os, string DeviceModel, string DeviceManufacturer);
