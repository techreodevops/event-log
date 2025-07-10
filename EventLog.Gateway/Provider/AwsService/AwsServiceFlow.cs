using EventLog.Middleware.Helpers.Constants;
using Flurl.Http;

namespace EventLog.Gateway.Provider.AwsService
{
    public static class AwsServiceFlow
    {
        public static async Task SaveLogAwsS3(object request)
        {
            IFlurlResponse http = await AwsServiceApi.SaveLogAwsS3(request);
            if (http.StatusCode != CommonConst.StatusCodeOK)
                throw new Exception("Error aws try save log !");
        }
    }
}
