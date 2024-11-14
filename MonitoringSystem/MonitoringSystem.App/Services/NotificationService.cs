using MonitoringSystem.App.Interfaces;
using MonitoringSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem.App.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationStorage _notificationStorage;

        public NotificationService(INotificationStorage notificationStorage)
        {
            _notificationStorage = notificationStorage;
        }

        public async Task<List<Notification>> GetNotificationsByUserIdAsync(Guid userId)
        {
            return await _notificationStorage.GetNotificationsByUserIdAsync(userId);
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            await _notificationStorage.AddNotificationAsync(notification);
        }
    }
}
