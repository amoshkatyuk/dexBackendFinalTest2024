using MonitoringSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringSystem.Data.EntityConfigurations
{
        public class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasKey(u => u.Id);

                builder.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                builder.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.HasMany(u => u.Buildings)
                    .WithOne(b => b.User)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }
}
