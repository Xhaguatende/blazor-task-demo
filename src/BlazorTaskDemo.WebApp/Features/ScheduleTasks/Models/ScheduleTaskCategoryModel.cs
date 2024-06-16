// -------------------------------------------------------------------------------------
//  <copyright file="ScheduleTaskCategoryModel.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorTaskDemo.WebApp.Features.ScheduleTasks.Models;

using System.ComponentModel.DataAnnotations;

public class ScheduleTaskCategoryModel
{
    public ScheduleTaskCategoryModel(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public ScheduleTaskCategoryModel()
    {
    }

    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = default!;
}