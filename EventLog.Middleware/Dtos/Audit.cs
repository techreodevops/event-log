namespace EventLog.Middleware.Dtos
{
    public class Audit
    {
        public string UserCreationId { get; set; } = "Log";
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string UserLastModifiedId { get; set; } = "Log";
        public DateTime DateLastModificationId { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
