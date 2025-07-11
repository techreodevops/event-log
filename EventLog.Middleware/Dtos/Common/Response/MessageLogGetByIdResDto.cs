namespace EventLog.Middleware.Dtos.Common.Response
{
    public sealed record MessageLogGetByIdResDto(
        string UserId,
        string Application,
        string Level,
        string Method,
        string Entity,
        string Message,
        string DateCreated
    );
}
