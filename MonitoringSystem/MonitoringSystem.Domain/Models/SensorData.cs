

namespace MonitoringSystem.Domain.Models
{
    public class SensorData
    {
        public Guid Id { get; set; }
        public Guid SensorId { get; set; }
        public Sensor Sensor { get; set; }
        public DateTime Timestamp { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float BatteryLevel { get; set; }
    }
}
