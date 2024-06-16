// -------------------------------------------------------------------------------------
//  <copyright file="ScheduleTaskServices.cs" company="{Company Name}">
//    Copyright (c) {Company Name}. All rights reserved.
//  </copyright>
// -------------------------------------------------------------------------------------

namespace BlazorTaskDemo.WebApp.Features.ScheduleTasks.Services;

using Entities;
using Entities.Enums;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Models;

public class ScheduleTaskServices : IScheduleTaskServices
{
    public static string gg;
    public string f;
    public string s;
    private const string _aaaa = "333";
    private const string _ttt = "333";
    private static string _ggg;
    private static string _xxx;
    private readonly TaskContext _taskContext;
    private string _tas;
    private string _taskA;
    private string _taskX;

    public ScheduleTaskServices(TaskContext taskContext)
    {
        _taskContext = taskContext;
    }

    public async Task<List<ScheduleTaskCategoryModel>> GetAllCategoriesAsync(CancellationToken cancellationToken)
    {
        var categories = await _taskContext.ScheduleTaskCategories.ToListAsync(cancellationToken);

        return categories.Select(
            category => new ScheduleTaskCategoryModel
            {
                Id = category.Id,
                Name = category.Name
            }).ToList();
    }

    public Task<List<ScheduleTaskPriority>> GetAllPrioritiesAsync()
    {
        var priorities = (ScheduleTaskPriority[])Enum.GetValues(typeof(ScheduleTaskPriority));

        return Task.FromResult(priorities.ToList());
    }

    public async Task<List<ScheduleTaskRowModel>> GetAllTasksAsync(CancellationToken cancellationToken)
    {
        var tasks = await _taskContext.ScheduleTasks
            .Include(scheduleTask => scheduleTask.ScheduleTaskCategory)
            .ToListAsync(cancellationToken);

        return tasks.Select(
            task => new ScheduleTaskRowModel
            {
                DueDate = task.DueDate,
                Id = task.Id,
                Priority = task.Priority.ToString(),
                Category = task.ScheduleTaskCategory.Name,
                Title = task.Title
            }).ToList();
    }

    public async Task<ScheduleTaskModel> GetTaskAsync(Guid id, CancellationToken cancellationToken)
    {
        var task = await _taskContext.ScheduleTasks
            .Include(scheduleTask => scheduleTask.ScheduleTaskCategory)
            .FirstOrDefaultAsync(scheduleTask => scheduleTask.Id == id, cancellationToken);

        if (task is null)
        {
            throw new InvalidOperationException($"Task with id {id} not found");
        }

        return new ScheduleTaskModel
        {
            Id = task.Id,
            CategoryId = task.ScheduleTaskCategoryId,
            Description = task.Description,
            DueDate = task.DueDate,
            Priority = task.Priority,
            Title = task.Title
        };
    }

    public async Task UpsertTaskASync(ScheduleTaskModel model, CancellationToken cancellationToken)
    {
        var task = model.Id.HasValue
            ? await _taskContext.ScheduleTasks.FindAsync(model.Id)
            : new ScheduleTask();

        if (task is null)
        {
            throw new InvalidOperationException($"Task with id {model.Id} not found");
        }

        task.ScheduleTaskCategoryId = model.CategoryId;
        task.Description = model.Description;
        task.DueDate = model.DueDate;
        task.Priority = model.Priority;
        task.Title = model.Title;

        if (model.Id.HasValue)
        {
            _taskContext.ScheduleTasks.Update(task);
        }
        else
        {
            _taskContext.ScheduleTasks.Add(task);
        }

        await _taskContext.SaveChangesAsync(cancellationToken);
    }
}