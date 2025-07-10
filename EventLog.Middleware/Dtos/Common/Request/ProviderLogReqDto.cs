namespace EventLog.Middleware.Dtos.Common.Request
{
    public sealed record ProviderLogReqDto(
        string UserId,
        string Provider,
        string Method,
        string Entity,
        string Url,
        string Headers,
        string Request,
        string Response,
        string StatusCode,
        bool IsError 
    );
}
