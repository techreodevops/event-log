using EventLog.Middleware.Contracts.Factories;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.API.Endpoints.EventLogs.ProviderLog
{
    public class GetByIdProviderLog : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("provider/{providerId}/{id}", async (string providerId, string id, Func<string, IServiceFactoryProvider> serviceFactoryProvider) =>
            {
                Res.GetByIdProviderLogResDto response = await serviceFactoryProvider(providerId).ProviderService.GetByIdProviderLogAsync(id);
                return Results.Ok(response);
            })
            .WithName("GetProviderLogById")
            .Produces<Res.GetByIdProviderLogResDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Provider Log By Id")
            .WithDescription("Get Provider Log By Id");
        }
    }
}
