// -------------------------------------------------------------------------------------
//  <copyright file="ScheduleTask.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorTaskDemo.WebApp.Features.ScheduleTasks.Entities;

using Enums;

public class ScheduleTask
{
    public ScheduleTask()
    {
        Id = Guid.NewGuid();
    }

    public string Description { get; set; } = default!;
    public DateTime DueDate { get; set; }
    public Guid Id { get; private set; }
    public ScheduleTaskPriority Priority { get; set; }
    public ScheduleTaskCategory ScheduleTaskCategory { get; set; } = default!;
    public Guid ScheduleTaskCategoryId { get; set; }
    public string Title { get; set; } = default!;
}