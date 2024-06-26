﻿// <auto-generated />
using System;
using BlazorTaskDemo.WebApp.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorTaskDemo.WebApp.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20240526165515_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorTaskDemo.WebApp.Features.ScheduleTasks.Entities.ScheduleTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ScheduleTaskCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleTaskCategoryId");

                    b.ToTable("ScheduleTask", (string)null);
                });

            modelBuilder.Entity("BlazorTaskDemo.WebApp.Features.ScheduleTasks.Entities.ScheduleTaskCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ScheduleTaskCategory", (string)null);
                });

            modelBuilder.Entity("BlazorTaskDemo.WebApp.Features.ScheduleTasks.Entities.ScheduleTask", b =>
                {
                    b.HasOne("BlazorTaskDemo.WebApp.Features.ScheduleTasks.Entities.ScheduleTaskCategory", "ScheduleTaskCategory")
                        .WithMany("ScheduleTasks")
                        .HasForeignKey("ScheduleTaskCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScheduleTaskCategory");
                });

            modelBuilder.Entity("BlazorTaskDemo.WebApp.Features.ScheduleTasks.Entities.ScheduleTaskCategory", b =>
                {
                    b.Navigation("ScheduleTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
