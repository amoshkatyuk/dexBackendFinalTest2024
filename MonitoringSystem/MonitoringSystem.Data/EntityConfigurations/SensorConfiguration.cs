using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MonitoringSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem.Data.EntityConfigurations
{
    public class SensorConfiguration : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Description)
                .HasMaxLength(200);

            builder.Property(s => s.PhotoUrl)
                .HasMaxLength(200);

            builder.Property(s => s.BatteryLevel)
                .IsRequired()
                .HasDefaultValue(100);

            builder.Property(s => s.TemperatureThresholdMin).IsRequired();
            builder.Property(s => s.TemperatureThresholdMax).IsRequired();
            builder.Property(s => s.HumidityThresholdMin).IsRequired();
            builder.Property(s => s.HumidityThresholdMax).IsRequired();

            builder.HasMany(s => s.Data)
                .WithOne(d => d.Sensor)
                .HasForeignKey(d => d.SensorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
