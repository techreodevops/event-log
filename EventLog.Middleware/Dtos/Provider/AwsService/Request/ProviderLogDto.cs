namespace EventLog.Middleware.Dtos.Provider.AwsService.Request
{
    public class ProviderLogDto : MainDto
    {
        public string Provider { get; set; }
        public string Method { get; set; }
        public string Url { get; set; }
        public object Headers { get; set; }
        public object Request { get; set; }
        public object Response { get; set; }
        public string StatusCode { get; set; }
        public bool IsError { get; set; }
    }
}
