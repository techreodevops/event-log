using EventLog.Middleware.Contracts.Factories;
using EventLog.Service.Provider.Aws;

namespace EventLog.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<Func<string, IServiceFactoryProvider>>(serviceFactory => key =>
            {
                return key switch
                {
                    "AWSS3" => serviceFactory.GetService<ServiceFactoryAws>(),
                    _ => throw new Exception("process invalid!")
                };
            });

            services.AddScoped<ServiceFactoryAws>();

            return services;
        }
    }
}
