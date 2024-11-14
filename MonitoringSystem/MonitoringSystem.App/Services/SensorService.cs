using MonitoringSystem.App.Interfaces;
using MonitoringSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem.App.Services
{
    public class SensorService : ISensorService
    {
        private readonly ISensorStorage _sensorStorage;

        public SensorService(ISensorStorage sensorStorage)
        {
            _sensorStorage = sensorStorage;
        }

        public async Task<List<Sensor>> GetSensorsByBuildingIdAsync(Guid buildingId)
        {
            return await _sensorStorage.GetSensorsByBuildingIdAsync(buildingId);
        }

        public async Task<Sensor> AddSensorAsync(Sensor sensor)
        {
            return await _sensorStorage.AddSensorAsync(sensor);
        }

        public async Task<Sensor> UpdateSensorAsync(Sensor sensor)
        {
            return await _sensorStorage.UpdateSensorAsync(sensor);
        }

        public async Task<bool> DeleteSensorAsync(Guid sensorId)
        {
            return await _sensorStorage.DeleteSensorAsync(sensorId);
        }
    }
}
