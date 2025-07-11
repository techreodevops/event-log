using EventLog.Middleware.Contracts.Factories;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.API.Endpoints.EventLogs.StructuredLog
{
    public class StructuredLogGetByIdEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
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
        }
    }
}
