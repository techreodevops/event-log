namespace EventLog.Middleware.Dtos.Provider.AwsService.Request
{
    public class StructuredLogDto : MainDto
    {
        public string Method { get; set; }
        public string Severity { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string Error { get; set; }
        public string Application { get; set; }
    }
}
