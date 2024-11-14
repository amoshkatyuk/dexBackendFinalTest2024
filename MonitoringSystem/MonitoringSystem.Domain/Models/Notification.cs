

namespace MonitoringSystem.Domain.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
    }
}
