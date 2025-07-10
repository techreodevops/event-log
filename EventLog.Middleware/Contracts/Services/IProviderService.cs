using Req = EventLog.Middleware.Dtos.Common.Request;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.Middleware.Contracts.Services
{
    public interface IProviderService
    {
        Task<Res.ProviderLogResDto> RegisterProviderAsync(Req.ProviderLogReqDto request);
    }
}
