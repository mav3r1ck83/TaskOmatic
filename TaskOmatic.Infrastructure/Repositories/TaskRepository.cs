using Microsoft.EntityFrameworkCore;
using TaskOmatic.Domain.Entities;
using TaskOmatic.Infrastructure;
using TaskOmatic.Application;
using TaskOmatic.Application.Interfaces.Repositories;

namespace TaskOmatic.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskOmaticDbContext _dbContext;

    public TaskRepository(TaskOmaticDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TaskEntry?> GetTaskById(int id, CancellationToken cancellationToken = default)
    {
        var task = await _dbContext.Task.FindAsync(new object[] { id }, cancellationToken);
        if (task is null || task.IsDeleted)
            throw new KeyNotFoundException($"Task with ID {id} not found.");

        return task;
    }

    public async Task<List<TaskEntry>> GetTasks(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Task.Where(t => !t.IsDeleted).ToListAsync(cancellationToken);
    }
    
    public async Task AddTask(TaskEntry task, CancellationToken cancellationToken = default)
    {
        await _dbContext.Task.AddAsync(task, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateTask(TaskEntry task, CancellationToken cancellationToken = default)
    {
        _dbContext.Task.Update(task);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteTask(int id, CancellationToken cancellationToken = default)
    {
        var task = await _dbContext.Task.FindAsync(new object[] { id }, cancellationToken);
        if (task is null) throw new KeyNotFoundException($"Task with ID {id} not found.");

        task.IsDeleted = true;
        _dbContext.Task.Update(task);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}