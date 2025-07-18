using EventLog.Middleware.Contracts.Factories;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.API.Endpoints.EventLogs.ProviderLog
{
    public static class ProviderLogGetByIdEndpoint
    {
        public static IEndpointRouteBuilder MapProviderLogGetByIdEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("provider/{providerId}/{id}", async (string providerId, string id, Func<string, IServiceFactoryProvider> serviceFactoryProvider) =>
            {
                Res.ProviderLogGetByIdResDto response = await serviceFactoryProvider(providerId).ProviderService.ProviderLogGetByIdAsync(id);
                return Results.Ok(response);
            })
            .WithName("GetProviderLogById")
            .Produces<Res.ProviderLogGetByIdResDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Provider Log By Id")
            .WithDescription("Get Provider Log By Id");

            return app;
        }
    }
}
