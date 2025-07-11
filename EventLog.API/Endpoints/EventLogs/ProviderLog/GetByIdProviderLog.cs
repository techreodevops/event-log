using EventLog.Middleware.Contracts.Factories;

namespace EventLog.API.Endpoints.EventLogs.ProviderLog
{
    public class GetByIdProviderLog : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("provider/{id}", (string id, Func<string, IServiceFactoryProvider> serviceFactoryProvider) =>
            {
                Results.Ok();
            })
            .WithName("GetProviderLogById")
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Provider Log By Id")
            .WithDescription("Get Provider Log By Id");
        }
    }
}
