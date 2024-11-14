using MonitoringSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem.App.Interfaces
{
    public interface ISensorDataStorage
    {
        public Task<List<SensorData>> GetSensorDataBySensorIdAndDateRangeAsync(Guid sensorId, DateTime startDate, DateTime endDate);
        public Task SaveSensorDataAsync(SensorData sensorData);
    }
}
