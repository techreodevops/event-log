using EventLog.Middleware.Contracts.Factories;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.API.Endpoints.EventLogs.TransactionLog
{
    public class TransactionLogGetByIdEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("transaction/{providerId}/{id}", async (string providerId, string id, Func<string, IServiceFactoryProvider> serviceFactoryProvider) =>
            {
                Res.TransactionLogGetByIdResDto response = await serviceFactoryProvider(providerId).ProviderService.TransactionLogGetByIdAsync(id);
                return Results.Ok(response);
            })
            .WithName("GetTransactionLogById")
            .Produces<Res.TransactionLogGetByIdResDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Transaction Log By Id")
            .WithDescription("Get Transaction Log By Id");
        }
    }
}
