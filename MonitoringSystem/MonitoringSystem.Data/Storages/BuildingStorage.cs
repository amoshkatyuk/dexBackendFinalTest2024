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
    public class BuildingStorage : IBuildingStorage
    {
        private readonly MonitoringSystemDbContext _context;
        public BuildingStorage(MonitoringSystemDbContext context)
        {
            _context = context;
        }
        public async Task<List<Building>> GetBuildingsByUserIdAsync(Guid userId)
        {
            return await _context.Buildings
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task<Building> AddBuildingAsync(Building building)
        {
            _context.Buildings.Add(building);
            await _context.SaveChangesAsync();

            return building;
        }

        public async Task<Building> UpdateBuildingAsync(Building building)
        {
            _context.Buildings.Update(building);
            await _context.SaveChangesAsync();

            return building;
        }

        public async Task<bool> DeleteBuildingAsync(Guid buildingId)
        {
            var building = await _context.Buildings.FindAsync(buildingId);
            if (building == null) return false;

            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
