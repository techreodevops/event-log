using Amazon.Athena;
using Amazon.Athena.Model;
using EventLog.Gateway.Provider.AwsService;
using EventLog.Middleware.Contracts.Services;
using EventLog.Middleware.Helpers.Aws;
using Enums = EventLog.Middleware.Enums;
using Req = EventLog.Middleware.Dtos.Common.Request;
using ReqAws = EventLog.Middleware.Dtos.Provider.AwsService.Request;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.Service.Provider.Aws
{
    public class AwsService(IAmazonAthena amazonAthena) : BaseService(amazonAthena), IAwsService
    {
        private readonly string awss3_uri = Environment.GetEnvironmentVariable("AWSS3_URI");
        private readonly string awsathena_db = Environment.GetEnvironmentVariable("AWSATHENA_DB");

        public async Task<Res.ProviderLogResDto> RegisterProviderLogAsync(Req.ProviderLogReqDto request)
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

        public async Task<Res.ProviderLogGetByIdResDto> ProviderLogGetByIdAsync(string id)
        {
            var queryRequest = new StartQueryExecutionRequest
            {
                QueryString = $"select * from {awsathena_db}.providerlogs where _id = '{id}' ",
                ResultConfiguration = new ResultConfiguration
                {
                    OutputLocation = $"{awss3_uri}/ProviderLog/"
                }
            };
            var result = await amazonAthena.QueryAsyncLight(queryRequest, 5);
            var row = result.ResultSet.Rows.Skip(1).FirstOrDefault() ?? throw new Exception("");
            var data = row.Data;

            Res.ProviderLogGetByIdResDto response = new(
                data[1].VarCharValue,
                data[2].VarCharValue,
                data[3].VarCharValue,
                data[4].VarCharValue,
                data[5].VarCharValue,
                data[6].VarCharValue,
                data[7].VarCharValue,
                data[8].VarCharValue,
                data[9].VarCharValue,
                data[10].VarCharValue,
                data[12].VarCharValue
            );

            return response;
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
        public async Task<Res.StructuredLogGetByIdResDto> StructuredLogGetByIdAsync(string id)
        {
            var queryRequest = new StartQueryExecutionRequest
            {
                QueryString = $"select * from {awsathena_db}.structuredlogs where _id = '{id}' ",
                ResultConfiguration = new ResultConfiguration
                {
                    OutputLocation = $"{awss3_uri}/StructuredLog/"
                }
            };
            var result = await amazonAthena.QueryAsyncLight(queryRequest, 5);
            var row = result.ResultSet.Rows.Skip(1).FirstOrDefault() ?? throw new Exception("");
            var data = row.Data;

            Res.StructuredLogGetByIdResDto response = new(
                data[1].VarCharValue,
                data[2].VarCharValue,
                data[3].VarCharValue,
                data[4].VarCharValue,
                data[5].VarCharValue,
                data[6].VarCharValue,
                data[7].VarCharValue,
                data[8].VarCharValue,
                data[9].VarCharValue,
                data[11].VarCharValue
            );

            return response;
        }

        public async Task<Res.MessageLogResDto> RegisterMessageLogAsync(Req.MessageLogReqDto request)
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

        public async Task<Res.MessageLogGetByIdResDto> MessageLogGetByIdAsync(string id)
        {
            var queryRequest = new StartQueryExecutionRequest
            {
                QueryString = $"select * from {awsathena_db}.messagelogs where _id = '{id}' ",
                ResultConfiguration = new ResultConfiguration
                {
                    OutputLocation = $"{awss3_uri}/MessageLog/"
                }
            };
            var result = await amazonAthena.QueryAsyncLight(queryRequest, 5);
            var row = result.ResultSet.Rows.Skip(1).FirstOrDefault() ?? throw new Exception("");
            var data = row.Data;

            Res.MessageLogGetByIdResDto response = new(
                data[1].VarCharValue,
                data[2].VarCharValue,
                data[3].VarCharValue,
                data[4].VarCharValue,
                data[5].VarCharValue,
                data[6].VarCharValue,
                data[8].VarCharValue
            );

            return response;
        }

        public async Task<Res.TransactionLogResDto> RegisterTransactionLogAsync(Req.TransactionLogReqDto request)
        {
            string id = Guid.NewGuid().ToString();

            Req.GeolocationReqDto geolocationReq = request.Geolocation;
            Req.TrackingDeviceReqDto trackingDeviceReq = request.TrackingDevice;

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

        public async Task<Res.TransactionLogGetByIdResDto> TransactionLogGetByIdAsync(string id)
        {
            var queryRequest = new StartQueryExecutionRequest
            {
                QueryString = $"select * from {awsathena_db}.transactionlogs where _id = '{id}' ",
                ResultConfiguration = new ResultConfiguration
                {
                    OutputLocation = $"{awss3_uri}/TransactionLog/"
                }
            };
            var result = await amazonAthena.QueryAsyncLight(queryRequest, 5);
            var row = result.ResultSet.Rows.Skip(1).FirstOrDefault() ?? throw new Exception("");
            var data = row.Data;

            Res.GeolocationResDto geolocation = new(data[7].VarCharValue, data[8].VarCharValue);
            Res.TrackingDeviceResDto trackingDevice = new(data[9].VarCharValue, data[10].VarCharValue, data[11].VarCharValue, data[12].VarCharValue, data[13].VarCharValue);
            Res.TransactionLogGetByIdResDto response = new(
                data[1].VarCharValue,
                data[2].VarCharValue,
                data[3].VarCharValue,
                data[4].VarCharValue,
                data[5].VarCharValue,
                data[6].VarCharValue,
                geolocation,
                trackingDevice,
                data[15].VarCharValue
            );

            return response;
        }
    }
}
