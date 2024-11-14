﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonitoringSystem.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MonitoringSystem.Data.Migrations
{
    [DbContext(typeof(MonitoringSystemDbContext))]
    partial class MonitoringSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MonitoringSystem.Domain.Models.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("MonitoringSystem.Domain.Models.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("MonitoringSystem.Domain.Models.Sensor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("BatteryLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(100f);

                    b.Property<Guid>("BuildingId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<float>("HumidityThresholdMax")
                        .HasColumnType("real");

                    b.Property<float>("HumidityThresholdMin")
                        .HasColumnType("real");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<float>("TemperatureThresholdMax")
                        .HasColumnType("real");

                    b.Property<float>("TemperatureThresholdMin")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("MonitoringSystem.Domain.Models.SensorData", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<float>("BatteryLevel")
                        .HasColumnType("real");

                    b.Property<float>("Humidity")
                        .HasColumnType("real");

                    b.Property<Guid>("SensorId")
                        .HasColumnType("uuid");

                    b.Property<float>("Temperature")
                        .HasColumnType("real");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("SensorId");

                    b.ToTable("SensorData");
                });

            modelBuilder.Entity("MonitoringSystem.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MonitoringSystem.Domain.Models.Building", b =>
                {
                    b.HasOne("MonitoringSystem.Domain.Models.User", "User")
                        .WithMany("Buildings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MonitoringSystem.Domain.Models.Notification", b =>
                {
                    b.HasOne("MonitoringSystem.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MonitoringSystem.Domain.Models.Sensor", b =>
                {
                    b.HasOne("MonitoringSystem.Domain.Models.Building", "Building")
                        .WithMany("Sensors")
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("MonitoringSystem.Domain.Models.SensorData", b =>
                {
                    b.HasOne("MonitoringSystem.Domain.Models.Sensor", "Sensor")
                        .WithMany("Data")
                        .HasForeignKey("SensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sensor");
                });

            modelBuilder.Entity("MonitoringSystem.Domain.Models.Building", b =>
                {
                    b.Navigation("Sensors");
                });

            modelBuilder.Entity("MonitoringSystem.Domain.Models.Sensor", b =>
                {
                    b.Navigation("Data");
                });

            modelBuilder.Entity("MonitoringSystem.Domain.Models.User", b =>
                {
                    b.Navigation("Buildings");
                });
#pragma warning restore 612, 618
        }
    }
}