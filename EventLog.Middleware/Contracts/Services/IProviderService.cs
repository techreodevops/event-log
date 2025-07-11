using Req = EventLog.Middleware.Dtos.Common.Request;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.Middleware.Contracts.Services
{
    public interface IProviderService
    {
        Task<Res.ProviderLogResDto> RegisterProviderLogAsync(Req.ProviderLogReqDto request);
        Task<Res.ProviderLogGetByIdResDto> ProviderLogGetByIdAsync(string id);
        Task<Res.StructuredLogResDto> RegisterStructuredLogAsync(Req.StructuredLogReqDto request);
        Task<Res.StructuredLogGetByIdResDto> StructuredLogGetByIdAsync(string id);
        Task<Res.MessageLogResDto> RegisterMessageLogAsync(Req.MessageLogReqDto request);
        Task<Res.MessageLogGetByIdResDto> MessageLogGetByIdAsync(string id);
        Task<Res.TransactionLogResDto> RegisterTransactionLogAsync(Req.TransactionLogReqDto request);
        Task<Res.TransactionLogGetByIdResDto> TransactionLogGetByIdAsync(string id);
    }
}
