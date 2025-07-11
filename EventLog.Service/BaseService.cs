using Amazon.Athena;

namespace EventLog.Service
{
    public class BaseService(IAmazonAthena amazonAthena)
    {
        protected readonly IAmazonAthena amazonAthena = amazonAthena;
    }
}
