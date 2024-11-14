using MonitoringSystem.App.Interfaces;
using MonitoringSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem.App.Services
{
    public class SensorDataService : ISensorDataService
    {
        private readonly ISensorDataStorage _sensorDataStorage;
        private readonly INotificationStorage _notificationStorage;
        public SensorDataService(ISensorDataStorage sensorDataStorage, INotificationStorage notificationStorage)
        {
            _sensorDataStorage = sensorDataStorage;
            _notificationStorage = notificationStorage;
        }

        public async Task<List<SensorData>> GetSensorDataBySensorIdAndDateRangeAsync(Guid sensorId, DateTime startDate, DateTime endDate)
        {
            return await _sensorDataStorage.GetSensorDataBySensorIdAndDateRangeAsync(sensorId, startDate, endDate);
        }

        public async Task ProcessSensorDataAsync(Sensor sensor, SensorData sensorData)
        {
            if (sensorData.Temperature < sensor.TemperatureThresholdMin || sensorData.Temperature > sensor.TemperatureThresholdMax)
            {
                var notification = new Notification
                {
                    UserId = sensor.Building.UserId,
                    Timestamp = DateTime.UtcNow,
                    Message = $"Значения температуры вышли за рамки, указанные пользователем для {sensor.Name}."
                };
                await _notificationStorage.AddNotificationAsync(notification);
            }

            if (sensorData.BatteryLevel < 10)
            {
                var notification = new Notification
                {
                    UserId = sensor.Building.UserId,
                    Timestamp = DateTime.UtcNow,
                    Message = $"Уровень батареи сенсора {sensor.Name}.менее 10%"
                };
                await _notificationStorage.AddNotificationAsync(notification);
            }

            await _sensorDataStorage.SaveSensorDataAsync(sensorData);
        }
    }
}
