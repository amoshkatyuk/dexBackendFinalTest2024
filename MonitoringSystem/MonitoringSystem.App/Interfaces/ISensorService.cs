using MonitoringSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem.App.Interfaces
{
    public interface ISensorService
    {
        public Task<List<Sensor>> GetSensorsByBuildingIdAsync(Guid buildingId);

        public Task<Sensor> AddSensorAsync(Sensor sensor);

        public Task<Sensor> UpdateSensorAsync(Sensor sensor);

        public Task<bool> DeleteSensorAsync(Guid sensorId);
    }
}
