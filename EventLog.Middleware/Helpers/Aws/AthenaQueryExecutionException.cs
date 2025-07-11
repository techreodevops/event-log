using Amazon.Athena.Model;

namespace EventLog.Middleware.Helpers.Aws
{
    public class AthenaQueryExecutionException : Exception
    {
        public GetQueryExecutionResponse GetQueryExecutionResponse { get; }
        public AthenaQueryExecutionException(string message, GetQueryExecutionResponse response) : base(message)
        {
            GetQueryExecutionResponse = response;
        }

        public AthenaQueryExecutionException(string message, GetQueryExecutionResponse response, Exception innerException) : base(message, innerException)
        {
            GetQueryExecutionResponse = response;
        }
    }
}
