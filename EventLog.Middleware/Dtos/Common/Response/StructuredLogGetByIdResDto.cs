namespace EventLog.Middleware.Dtos.Common.Response
{
    public sealed record StructuredLogGetByIdResDto(
        string Entity,
        string UserId,
        string Application,
        string Severity,
        string Source,
        string Method,
        string Message,
        string StackTrace,
        string Error,
        string CreationDate
    );
}
