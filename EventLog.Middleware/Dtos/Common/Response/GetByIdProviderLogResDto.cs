namespace EventLog.Middleware.Dtos.Common.Response;

public sealed record GetByIdProviderLogResDto(
    string UserId,
    string Provider,
    string Method,
    string Entity,
    string Url,
    string Headers,
    string Request,
    string Response,
    string StatusCode,
    string IsError,
    string CreationDate
);
