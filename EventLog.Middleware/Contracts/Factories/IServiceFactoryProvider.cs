using EventLog.Middleware.Contracts.Services;
namespace EventLog.Middleware.Contracts.Factories
{
    public interface IServiceFactoryProvider
    {
        IProviderService ProviderService { get; }
    }
}
