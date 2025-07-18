using EventLog.Middleware.Contracts.Factories;
using Req = EventLog.Middleware.Dtos.Common.Request;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.API.Endpoints.EventLogs.StructuredLog
{
    public static class AddStructuredLogEndpoint
    {
        public static IEndpointRouteBuilder MapAddStructuredLogEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("structured", async (Req.StructuredLogReqDto request, Func<string, IServiceFactoryProvider> serviceFactoryProvider) =>
            {
                Res.StructuredLogResDto response = await serviceFactoryProvider(request.ProviderId).ProviderService.RegisterStructuredLogAsync(request);
                return Results.Ok(response);
            })
            .WithName("AddStructuredLog")
            .Produces<Res.StructuredLogResDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Add Structured Log")
            .WithDescription("Add Structured Log");

            return app;
        }
    }
}
