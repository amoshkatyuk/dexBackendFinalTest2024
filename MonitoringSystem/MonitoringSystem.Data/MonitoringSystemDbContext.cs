using Microsoft.EntityFrameworkCore;
using MonitoringSystem.Domain.Models;
using System.Reflection;


namespace MonitoringSystem.Data
{
    public class MonitoringSystemDbContext : DbContext
    {
        //public MonitoringSystemDbContext(DbContextOptions<MonitoringSystemDbContext> options)
        //    : base(options)
        //{
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorData> SensorData { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=monitoringsystem;Username=postgres;Password=admin");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
