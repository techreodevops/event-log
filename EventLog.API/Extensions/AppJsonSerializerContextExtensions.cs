using System.Text.Json.Serialization;
using Req = EventLog.Middleware.Dtos.Common.Request;
using Res = EventLog.Middleware.Dtos.Common.Response;

namespace EventLog.API.Extensions
{
    public static class AppJsonSerializerContextExtensions
    {
        public static IServiceCollection AddConfigureHttpJsonOptions(this IServiceCollection services)
        {
            services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
            });

            return services;
        }
    }
}

[JsonSerializable(typeof(Req.MessageLogReqDto))]
[JsonSerializable(typeof(Res.MessageLogGetByIdResDto))]
[JsonSerializable(typeof(Req.ProviderLogReqDto))]
[JsonSerializable(typeof(Res.ProviderLogGetByIdResDto))]
[JsonSerializable(typeof(Req.StructuredLogReqDto))]
[JsonSerializable(typeof(Res.StructuredLogGetByIdResDto))]
[JsonSerializable(typeof(Req.TransactionLogReqDto))]
[JsonSerializable(typeof(Res.TransactionLogGetByIdResDto))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }