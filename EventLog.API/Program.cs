using EventLog.API.Extensions;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);
IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddSwaggerGenWithAuth();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddEndpoints(Assembly.GetExecutingAssembly());
services.AddConfigureHttpJsonOptions();

services.AddDependencyInjection();

services.AddAws(configuration);

WebApplication app = builder.Build();

app.MapEndpoints();

app.UseSwagger(c => c.RouteTemplate = "/event-log/swagger/v1/{documentName}/swagger.json");
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("provider/swagger.json", "ProviderLog");
    c.RoutePrefix = "event-log/swagger/v1";
});

app.Run();