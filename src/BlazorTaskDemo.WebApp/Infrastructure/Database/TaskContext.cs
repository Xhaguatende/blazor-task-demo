// -------------------------------------------------------------------------------------
//  <copyright file="TaskContext.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorTaskDemo.WebApp.Infrastructure.Database;

using Features.ScheduleTasks.Entities;
using Microsoft.EntityFrameworkCore;

public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options)
    {
    }

    public DbSet<ScheduleTaskCategory> ScheduleTaskCategories { get; set; } = default!;
    public DbSet<ScheduleTask> ScheduleTasks { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ScheduleTask>()
            .HasOne(x => x.ScheduleTaskCategory)
            .WithMany(x => x.ScheduleTasks)
            .HasForeignKey(x => x.ScheduleTaskCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ScheduleTask>(
            entity =>
            {
                entity.ToTable("ScheduleTask");

                entity.Property(e => e.Id)
                    .HasColumnOrder(0);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnOrder(1);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnOrder(2);

                entity.Property(e => e.Priority)
                    .HasConversion<string>()
                    .HasColumnOrder(3);

                entity.Property(e => e.DueDate)
                    .HasColumnType("date")
                    .HasColumnOrder(4);
            });

        modelBuilder.Entity<ScheduleTaskCategory>(
            entity =>
            {
                entity.ToTable("ScheduleTaskCategory");

                entity.Property(e => e.Name)
                    .HasMaxLength(100);
            });
    }
}