using EventLog.Middleware.Helpers.Constants;
using Flurl.Http;

namespace EventLog.Gateway.Provider.AwsService
{
    internal static class AwsServiceApi
    {
        private static readonly string baseUrl = Environment.GetEnvironmentVariable(CommonConst.AWSS3_URL);
        private static readonly string apiKey = Environment.GetEnvironmentVariable(CommonConst.AWSS3_API_KEY);

        public static async Task<IFlurlResponse> SaveLogAwsS3(object request)
        {

            IFlurlResponse http = await baseUrl
                                        .WithHeader("x-api-key", apiKey)
                                        .AllowAnyHttpStatus()
                                        .PostJsonAsync(request);
            return http;
        }
    }
}
