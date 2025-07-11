namespace EventLog.Middleware.Dtos.Common.Response
{
    public sealed record TransactionLogGetByIdResDto(
        string Entity,
        string UserId,
        string Application,
        string IdDevice,
        string IsToken,
        string TransactiontType,
        GeolocationResDto Geolocation,
        TrackingDeviceResDto TrackingDevice,
        string DateCreated
    );

    public sealed record GeolocationResDto(string Latitude, string Longitude);

    public sealed record TrackingDeviceResDto(string AppVersion, string OsVersion, string Os, string DeviceModel, string DeviceManufacturer);
}
