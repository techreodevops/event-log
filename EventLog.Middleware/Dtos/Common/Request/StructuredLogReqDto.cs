namespace EventLog.Middleware.Dtos.Common.Request
{
    public sealed record StructuredLogReqDto(
        string ProviderId,
        string UserId,
        string Entity,
        string Method,
        string Severity,
        string Message,
        string Source,
        string StackTrace,
        string Error,
        string Application
    );
}
