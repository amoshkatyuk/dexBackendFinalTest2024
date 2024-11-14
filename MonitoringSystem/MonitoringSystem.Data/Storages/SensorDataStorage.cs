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
    public class SensorDataStorage : ISensorDataStorage
    {
        private readonly MonitoringSystemDbContext _context;

        public SensorDataStorage(MonitoringSystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<SensorData>> GetSensorDataBySensorIdAndDateRangeAsync(Guid sensorId, DateTime startDate, DateTime endDate)
        {
            return await _context.SensorData
                .Where(sd => sd.SensorId == sensorId && sd.Timestamp >= startDate && sd.Timestamp <= endDate)
                .ToListAsync();
        }

        public async Task SaveSensorDataAsync(SensorData sensorData) 
        {
            await _context.SensorData.AddAsync(sensorData);
            await _context.SaveChangesAsync();
        }
    }
}

