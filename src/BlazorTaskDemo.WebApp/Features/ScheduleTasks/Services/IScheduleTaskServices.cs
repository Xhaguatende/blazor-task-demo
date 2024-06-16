// -------------------------------------------------------------------------------------
//  <copyright file="IScheduleTaskServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorTaskDemo.WebApp.Features.ScheduleTasks.Services;

using Entities.Enums;
using Models;

public interface IScheduleTaskServices
{
    Task<List<ScheduleTaskCategoryModel>> GetAllCategoriesAsync(CancellationToken cancellationToken);

    Task<List<ScheduleTaskPriority>> GetAllPrioritiesAsync();

    Task<List<ScheduleTaskRowModel>> GetAllTasksAsync(CancellationToken cancellationToken);

    Task<ScheduleTaskModel> GetTaskAsync(Guid id, CancellationToken cancellationToken);

    Task UpsertTaskASync(ScheduleTaskModel model, CancellationToken cancellationToken);
}