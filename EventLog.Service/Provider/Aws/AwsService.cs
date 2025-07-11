using EventLog.Gateway.Provider.AwsService;
using EventLog.Middleware.Contracts.Services;
using Req = EventLog.Middleware.Dtos.Common.Request;
using Res = EventLog.Middleware.Dtos.Common.Response;
using ReqAws = EventLog.Middleware.Dtos.Provider.AwsService.Request;
using Enums = EventLog.Middleware.Enums;

namespace EventLog.Service.Provider.Aws
{
    public class AwsService : IAwsService
    {
        public async Task<Res.ProviderLogResDto> RegisterProviderAsync(Req.ProviderLogReqDto request)
        {
            string id = Guid.NewGuid().ToString();
            ReqAws.ProviderLogDto providerLog = new() 
            {
                Id = id,
                LogType = nameof(Enums.LogType.ProviderLog),
                UserId = request.UserId,
                Entity = request.Entity,
                Method = request.Method,
                Provider = request.Provider,
                Url = request.Url,
                Headers = request.Headers,
                Request = request.Request,
                Response = request.Response,
                StatusCode = request.StatusCode,
                IsError = request.IsError,
            };

            await AwsServiceFlow.SaveLogAwsS3(providerLog);

            return new Res.ProviderLogResDto(id);
        }

        public async Task<Res.StructuredLogResDto> RegisterStructuredLogAsync(Req.StructuredLogReqDto request)
        {
            string id = Guid.NewGuid().ToString();
            ReqAws.StructuredLogDto structuredLog = new()
            {
                Id = id,
                LogType = nameof(Enums.LogType.StructuredLog),
                Entity = request.Entity,
                UserId =request.UserId,
                Application = request.Application,
                Severity = request.Severity,
                Source = request.Source,
                Method =request.Method,
                Message = request.Message,
                StackTrace = request.StackTrace,
                Error = request.Error,
            };

            await AwsServiceFlow.SaveLogAwsS3(structuredLog);

            return new Res.StructuredLogResDto(id);
        }

        public async Task<Res.MessageLogResDto> RegisterMessageAsync(Req.MessageLogReqDto request)
        {
            string id = Guid.NewGuid().ToString();
            ReqAws.MessageLogDto messageLog = new()
            {
                Id = id,
                LogType = nameof(Enums.LogType.MessageLog),
                UserId = request.UserId,
                Application = request.Application,
                Level = request.Level,
                Method = request.Method,
                Entity = request.Entity,
                Message = request.Message
            };

            await AwsServiceFlow.SaveLogAwsS3(messageLog);

            return new Res.MessageLogResDto(id);
        }

        public async Task<Res.TransactionLogResDto> RegisterTransactionLogAsync(Req.TransactionLogReqDto request)
        {
            string id = Guid.NewGuid().ToString();

            Req.Geolocation geolocationReq = request.Geolocation;
            Req.TrackingDevice trackingDeviceReq = request.TrackingDevice;

            ReqAws.GeolocationTransactionLogDto geolocation = new(geolocationReq.Latitude, geolocationReq.Longitude);
            ReqAws.TrackingDeviceTransactionLogDto trackingDevice = new(
                trackingDeviceReq.AppVersion,
                trackingDeviceReq.OsVersion,
                trackingDeviceReq.Os,
                trackingDeviceReq.DeviceModel,
                trackingDeviceReq.DeviceManufacturer
            );

            ReqAws.TransactionLogDto transactionLog = new()
            {
                Id = id,
                LogType = nameof(Enums.LogType.TransactionLog),
                Entity = request.Entity,
                UserId = request.UserId,
                Application = request.Application,
                IdDevice = request.IdDevice,
                IsToken = request.IsToken,
                TransactiontType = request.TransactionType,
                Geolocation = geolocation,
                TrackingDevice = trackingDevice
            };

            await AwsServiceFlow.SaveLogAwsS3(transactionLog);

            return new Res.TransactionLogResDto(id);
        }
    }
}
