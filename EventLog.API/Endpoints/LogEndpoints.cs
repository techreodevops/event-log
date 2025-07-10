using EventLog.Middleware.Contracts.Factories;
using Req = EventLog.Middleware.Dtos.Common.Request;

namespace EventLog.API.Endpoints
{
    public class LogEndpoints(Func<string, IServiceFactoryProvider> serviceFactoryProvider)
    {
        private Func<string, IServiceFactoryProvider> serviceFactoryProvider = serviceFactoryProvider;

        public void AddLogEndpoints(WebApplication app)
        {
            RouteGroupBuilder logsApi = app.MapGroup("/log");
            ProviderLogEndpoints(logsApi);
        }

        private void ProviderLogEndpoints(RouteGroupBuilder logsApi)
        {
            logsApi.MapPost("/provider", async (Req.ProviderLogReqDto request) =>
            {
                await serviceFactoryProvider("AWSS3").ProviderService.RegisterProviderAsync(request);
            })
            .WithName("AddProviderLog")
            .Produces(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Add Provider Log")
            .WithDescription("Add Provider Log");

            logsApi.MapGet("/provider/{id}", (string id) =>
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
