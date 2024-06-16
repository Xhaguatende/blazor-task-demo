// -------------------------------------------------------------------------------------
//  <copyright file="ScheduleTaskCategory.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorTaskDemo.WebApp.Features.ScheduleTasks.Entities;

public class ScheduleTaskCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public ICollection<ScheduleTask> ScheduleTasks { get; } = new HashSet<ScheduleTask>();
}