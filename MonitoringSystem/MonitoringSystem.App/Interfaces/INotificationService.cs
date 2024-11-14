using MonitoringSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem.App.Interfaces
{
    public interface INotificationService
    {
        public Task<List<Notification>> GetNotificationsByUserIdAsync(Guid userId);

        public Task AddNotificationAsync(Notification notification);
    }
}
