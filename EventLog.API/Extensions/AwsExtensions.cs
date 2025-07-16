using Amazon.Athena;

namespace EventLog.API.Extensions
{
    public static class AwsExtensions
    {
        public static IServiceCollection AddAws(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultAWSOptions(configuration.GetAWSOptions());
            services.AddAWSService<IAmazonAthena>();

            return services;
        }
    }
}
