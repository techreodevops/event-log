using EventLog.Gateway.Provider.AwsService;
using EventLog.Middleware.Contracts.Services;
using Newtonsoft.Json;
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
            ReqAws.ProviderLogDto providerLog = new() {
                Id = id,
                LogType = nameof(Enums.LogType.ProviderLog),
                UserId = request.UserId,
                Entity = request.Entity,
                Method =request.Method,
                Provider = request.Provider,
                Url = request.Url,
                Headers = JsonConvert.SerializeObject(request.Headers),
                Request = JsonConvert.SerializeObject(request.Request),
                Response = JsonConvert.SerializeObject(request.Response),
                StatusCode = request.StatusCode,
                IsError = request.IsError,
            };

            await AwsServiceFlow.SaveLogAwsS3(providerLog);

            return new Res.ProviderLogResDto(id);
        }

        public async Task<Res.StructuredLogResDto> RegisterStructuredLAsync(Req.StructuredLogReqDto request)
        {
            string id = Guid.NewGuid().ToString();
            ReqAws.StructuredLogDto structuredLog = new()
            {
                Id = id,
                LogType = nameof(Enums.LogType.StructuredLog),
                UserId =request.UserId,
                Entity = request.Entity,
                Method =request.Method,
                Severity = request.Severity,
                Message = request.Message,
                Source = request.Source,
                StackTrace = request.StackTrace,
                Error = request.Error,
                Application = request.Application
            };

            await AwsServiceFlow.SaveLogAwsS3(structuredLog);

            return new Res.StructuredLogResDto(id);
        }
    }
}
