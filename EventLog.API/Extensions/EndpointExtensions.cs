using EventLog.API.Endpoints.EventLogs.MessageLog;
using EventLog.API.Endpoints.EventLogs.ProviderLog;
using EventLog.API.Endpoints.EventLogs.StructuredLog;
using EventLog.API.Endpoints.EventLogs.TransactionLog;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.API.Extensions
{
    public static class EndpointExtensions
    {
        public static IEndpointRouteBuilder MapTesApi(this IEndpointRouteBuilder app)
        {
            app.MapGet("test", () =>
            {
                Res.EventLogTestResDto response = new(DateTime.UtcNow, "1.0");
                return Results.Ok(response);
            });

            return app;
        }

        public static IEndpointRouteBuilder MapMessageApi(this IEndpointRouteBuilder app)
        {
            app.MapAddMessageLogEndpoint();
            app.MapMessageLogGetByIdEndpoint();

            return app;
        }

        public static IEndpointRouteBuilder MapProviderApi(this IEndpointRouteBuilder app)
        {
            app.MapAddProviderLogEndpoint();
            app.MapProviderLogGetByIdEndpoint();

            return app;
        }

        public static IEndpointRouteBuilder MapStructuredLogApi(this IEndpointRouteBuilder app)
        {
            app.MapAddStructuredLogEndpoint();
            app.MapStructuredLogGetByIdEndpoint();

            return app;
        }

        public static IEndpointRouteBuilder MapTransactionLogApi(this IEndpointRouteBuilder app)
        {
            app.MapAddTransactionLogEndpoint();
            app.MapTransactionLogGetByIdEndpoint();

            return app;
        }
    }
}
