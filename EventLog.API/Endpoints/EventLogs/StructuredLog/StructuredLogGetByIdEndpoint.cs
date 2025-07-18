using EventLog.Middleware.Contracts.Factories;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.API.Endpoints.EventLogs.StructuredLog
{
    public static class StructuredLogGetByIdEndpoint
    {
        public static IEndpointRouteBuilder MapStructuredLogGetByIdEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("structured/{providerId}/{id}", async (string providerId, string id, Func<string, IServiceFactoryProvider> serviceFactoryProvider) =>
            {
                Res.StructuredLogGetByIdResDto response = await serviceFactoryProvider(providerId).ProviderService.StructuredLogGetByIdAsync(id);
                return Results.Ok(response);
            })
            .WithName("GetStructuredLogById")
            .Produces<Res.StructuredLogGetByIdResDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Structured Log By Id")
            .WithDescription("Get Structured Log By Id");

            return app;
        }
    }
}
