using EventLog.Middleware.Contracts.Factories;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.API.Endpoints.EventLogs.MessageLog
{
    public static class MessageLogGetByIdEndpoint
    {
        public static IEndpointRouteBuilder MapMessageLogGetByIdEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("message/{providerId}/{id}", async (string providerId, string id, Func<string, IServiceFactoryProvider> serviceFactoryProvider) =>
            {
                Res.MessageLogGetByIdResDto response = await serviceFactoryProvider(providerId).ProviderService.MessageLogGetByIdAsync(id);
                return Results.Ok(response);
            })
            .WithName("GetMessageLogById")
            .Produces<Res.MessageLogGetByIdResDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Message Log By Id")
            .WithDescription("Get Message Log By Id");

            return app;
        }
    }
}
