using EventLog.Middleware.Contracts.Factories;
using Req = EventLog.Middleware.Dtos.Common.Request;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.API.Endpoints.EventLogs.MessageLog
{
    public class AddMessageLogEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("message", async (Req.MessageLogReqDto request, Func<string, IServiceFactoryProvider> serviceFactoryProvider) =>
            {
                Res.MessageLogResDto response = await serviceFactoryProvider(request.ProviderId).ProviderService.RegisterMessageAsync(request);
                return Results.Ok(response);
            })
            .WithName("AddMessageLog")
            .Produces<Res.MessageLogResDto>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Add Message Log")
            .WithDescription("Add Message Log");
        }
    }
}
