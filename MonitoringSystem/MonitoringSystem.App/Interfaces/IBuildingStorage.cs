using MonitoringSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem.App.Interfaces
{
    public interface IBuildingStorage
    {
        public Task<List<Building>> GetBuildingsByUserIdAsync(Guid userId);
        public Task<Building> AddBuildingAsync(Building building);
        public Task<Building> UpdateBuildingAsync(Building building);
        public Task<bool> DeleteBuildingAsync(Guid buildingId);

    }
}
