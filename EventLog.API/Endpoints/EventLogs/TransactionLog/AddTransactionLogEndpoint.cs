using EventLog.Middleware.Contracts.Factories;
using Req = EventLog.Middleware.Dtos.Common.Request;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.API.Endpoints.EventLogs.TransactionLog
{
    public static class AddTransactionLogEndpoint
    {
        public static IEndpointRouteBuilder MapAddTransactionLogEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapPost("transaction", async (Req.TransactionLogReqDto request, Func<string, IServiceFactoryProvider> serviceFactoryProvider) =>
            {
                Res.TransactionLogResDto response = await serviceFactoryProvider(request.ProviderId).ProviderService.RegisterTransactionLogAsync(request);
                return Results.Ok(response);
            })
            .WithName("AddTransactionLog")
            .Produces<Res.TransactionLogResDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Add Transaction Log")
            .WithDescription("Add Transaction Log");

            return app;
        }
    }
}
