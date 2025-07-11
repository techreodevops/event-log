using EventLog.Middleware.Contracts.Factories;
using Req = EventLog.Middleware.Dtos.Common.Request;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.API.Endpoints.EventLogs.ProviderLog
{
    public class AddProviderLogEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("provider", async (Req.ProviderLogReqDto request, Func<string, IServiceFactoryProvider> serviceFactoryProvider) =>
            {
                Res.ProviderLogResDto response = await serviceFactoryProvider(request.ProviderId).ProviderService.RegisterProviderAsync(request);
                Results.Ok(response);
            })
            .WithName("AddProviderLog")
            .Produces<Res.ProviderLogResDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Add Provider Log")
            .WithDescription("Add Provider Log");
        }
    }
}
