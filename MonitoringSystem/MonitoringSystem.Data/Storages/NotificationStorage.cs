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
    public class NotificationStorage : INotificationStorage
    {
        private readonly MonitoringSystemDbContext _context;

        public NotificationStorage(MonitoringSystemDbContext context)
        {
            _context = context;
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteNotificationAsync(Guid notificationId) 
        {
            var notification = await _context.Notifications.FindAsync(notificationId);
            if (notification == null) return false;

            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Notification>> GetNotificationsByUserIdAsync(Guid userId)
        {
            return await _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.Timestamp)
                .ToListAsync();
        }
    }
}

