using Microsoft.EntityFrameworkCore;
using MonitoringSystem.App.Interfaces;
using MonitoringSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem.Data.Storages
{
    public class SensorStorage : ISensorStorage
    {
        private readonly MonitoringSystemDbContext _context;

        public SensorStorage(MonitoringSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sensor>> GetSensorsByBuildingIdAsync(Guid buildingId)
        {
            return await _context.Sensors
                .Where(s => s.BuildingId == buildingId)
                .ToListAsync();
        }

        public async Task<Sensor> AddSensorAsync(Sensor sensor)
        {
            _context.Sensors.Add(sensor);
            await _context.SaveChangesAsync();

            return sensor;
        }

        public async Task<Sensor> UpdateSensorAsync(Sensor sensor)
        {
            _context.Sensors.Update(sensor);
            await _context.SaveChangesAsync();

            return sensor;
        }

        public async Task<bool> DeleteSensorAsync(Guid sensorId)
        {
            var sensor = await _context.Sensors.FindAsync(sensorId);
            if (sensor == null) return false;

            _context.Sensors.Remove(sensor);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
