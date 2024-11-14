

namespace MonitoringSystem.Domain.Models
{
    public class Sensor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PhotoUrl { get; set; }
        public float BatteryLevel { get; set; }
        public float TemperatureThresholdMin { get; set; }
        public float TemperatureThresholdMax { get; set; }
        public float HumidityThresholdMin { get; set; }
        public float HumidityThresholdMax { get; set; }

        public Guid BuildingId { get; set; }
        public Building Building { get; set; }

        public List<SensorData> Data { get; set; }
    }
}
