using EventLog.API.Extensions;

WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);
IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

//services.AddSwaggerGenWithAuth();
//services.AddEndpointsApiExplorer();
//services.AddSwaggerGen();

services.AddConfigureHttpJsonOptions();

services.AddDependencyInjection();

services.AddAws(configuration);

WebApplication app = builder.Build();



RouteGroupBuilder eventLogApi = app.MapGroup("/event-log");

eventLogApi.MapTesApi()
           .MapMessageApi()
           .MapProviderApi()
           .MapStructuredLogApi()
           .MapTransactionLogApi();

//app.UseSwagger(c => c.RouteTemplate = "/event-log/swagger/v1/{documentName}/swagger.json");
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("provider/swagger.json", "ProviderLog");
//    c.RoutePrefix = "event-log/swagger/v1";
//});

app.Run();