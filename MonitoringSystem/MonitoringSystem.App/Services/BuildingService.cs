using MonitoringSystem.App.Interfaces;
using MonitoringSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem.App.Services
{
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingStorage _buildingStorage;

        public BuildingService(IBuildingStorage buildingStorage)
        {
            _buildingStorage = buildingStorage;
        }
        public async Task<List<Building>> GetBuildingsByUserIdAsync(Guid userId)
        {
            return await _buildingStorage.GetBuildingsByUserIdAsync(userId);
        }

        public async Task<Building> AddBuildingAsync(Building building)
        {
            return await _buildingStorage.AddBuildingAsync(building);
        }

        public async Task<Building> UpdateBuildingAsync(Building building)
        {
            return await _buildingStorage.UpdateBuildingAsync(building);
        }

        public async Task<bool> DeleteBuildingAsync(Guid buildingId)
        {
            return await _buildingStorage.DeleteBuildingAsync(buildingId);
        }
    }
}
