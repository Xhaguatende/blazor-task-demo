// -------------------------------------------------------------------------------------
//  <copyright file="ScheduleTaskModel.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorTaskDemo.WebApp.Features.ScheduleTasks.Models;

using System.ComponentModel.DataAnnotations;
using Entities.Enums;

public class ScheduleTaskModel
{
    [Required]
    public Guid CategoryId { get; set; }

    [Required]
    [StringLength(1000)]
    public string Description { get; set; } = default!;

    [Required]
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }

    public Guid? Id { get; set; }

    [Required]
    public ScheduleTaskPriority Priority { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = default!;
}