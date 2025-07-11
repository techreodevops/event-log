using Amazon.Athena;
using EventLog.API.Extensions;
using EventLog.Middleware.Contracts.Factories;
using EventLog.Middleware.Dtos.Common.Request;
using EventLog.Middleware.Dtos.Common.Response;
using EventLog.Service.Provider.Aws;
using System.Reflection;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);
IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

services.AddSwaggerGenWithAuth();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddEndpoints(Assembly.GetExecutingAssembly());

services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

services.AddScoped<Func<string, IServiceFactoryProvider>>(serviceFactory => key =>
{
    return key switch
    {
        "AWSS3" => serviceFactory.GetService<ServiceFactoryAws>(),
        _ => throw new Exception("process invalid!")
    };
});

services.AddScoped<ServiceFactoryAws>();

services.AddDefaultAWSOptions(configuration.GetAWSOptions());
services.AddAWSService<IAmazonAthena>();


WebApplication app = builder.Build();


app.MapEndpoints();

app.UseSwagger(c => c.RouteTemplate = "/event-log/swagger/v1/{documentName}/swagger.json");
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("provider/swagger.json", "ProviderLog");
    c.RoutePrefix = "event-log/swagger/v1";
});

app.Run();

[JsonSerializable(typeof(MessageLogReqDto))]
[JsonSerializable(typeof(ProviderLogReqDto))]
[JsonSerializable(typeof(StructuredLogReqDto))]
[JsonSerializable(typeof(TransactionLogReqDto))]
[JsonSerializable(typeof(GetByIdProviderLogResDto))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }
