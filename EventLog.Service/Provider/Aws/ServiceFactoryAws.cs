using Amazon.Athena;
using EventLog.Middleware.Contracts.Factories;
using EventLog.Middleware.Contracts.Services;

namespace EventLog.Service.Provider.Aws
{
    public class ServiceFactoryAws(IAmazonAthena amazonAthena) : IServiceFactoryProvider
    {
        protected readonly IAmazonAthena amazonAthena = amazonAthena;

        private IAwsService awsService;

        public IProviderService ProviderService => awsService ??= new AwsService(amazonAthena);
    }
}
