// -------------------------------------------------------------------------------------
//  <copyright file="ScheduleTaskRowModel.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorTaskDemo.WebApp.Features.ScheduleTasks.Models;
public class ScheduleTaskRowModel
{
    public DateTime DueDate { get; set; }
    public Guid Id { get; set; }
    public string Priority { get; set; } = default!;
    public string Category { get; set; } = default!;
    public string Title { get; set; } = default!;
}