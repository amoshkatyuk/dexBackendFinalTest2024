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
    public class SensorDataConfiguration : IEntityTypeConfiguration<SensorData>
    {
        public void Configure(EntityTypeBuilder<SensorData> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Timestamp)
                .IsRequired();

            builder.Property(d => d.Temperature)
                .IsRequired();

            builder.Property(d => d.Humidity)
                .IsRequired();

            builder.Property(d => d.BatteryLevel)
                .IsRequired();
        }
    }
}
