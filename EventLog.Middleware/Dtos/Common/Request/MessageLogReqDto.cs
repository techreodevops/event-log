namespace EventLog.Middleware.Dtos.Common.Request;

public sealed record MessageLogReqDto(
    string ProviderId,
    string UserId,
    string Entity,
    string Application,
    string Level,
    string Method,
    string Message
);
