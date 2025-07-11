using Req = EventLog.Middleware.Dtos.Common.Request;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.Middleware.Contracts.Services
{
    public interface IProviderService
    {
        Task<Res.ProviderLogResDto> RegisterProviderLogAsync(Req.ProviderLogReqDto request);
        Task<Res.GetByIdProviderLogResDto> GetByIdProviderLogAsync(string id);
        Task<Res.StructuredLogResDto> RegisterStructuredLogAsync(Req.StructuredLogReqDto request);
        Task<Res.MessageLogResDto> RegisterMessageAsync(Req.MessageLogReqDto request);
        Task<Res.TransactionLogResDto> RegisterTransactionLogAsync(Req.TransactionLogReqDto request);
    }
}
