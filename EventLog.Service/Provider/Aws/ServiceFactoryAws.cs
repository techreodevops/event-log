using EventLog.Middleware.Contracts.Factories;
using EventLog.Middleware.Contracts.Services;

namespace EventLog.Service.Provider.Aws
{
    public class ServiceFactoryAws : IServiceFactoryProvider
    {
        private IAwsService awsService;

        public IProviderService ProviderService => awsService ??= new AwsService();
    }
}
