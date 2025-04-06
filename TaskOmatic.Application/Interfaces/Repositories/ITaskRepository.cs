using TaskOmatic.Domain.Entities;

namespace TaskOmatic.Application.Interfaces.Repositories;


public interface ITaskRepository
{
    Task<TaskEntry?> GetTaskById(int id, CancellationToken cancellationToken = default);
    Task<List<TaskEntry>> GetTasks(CancellationToken cancellationToken = default);
    Task AddTask(TaskEntry task, CancellationToken cancellationToken = default);
    Task UpdateTask(TaskEntry task, CancellationToken cancellationToken = default);
    Task DeleteTask(int id, CancellationToken cancellationToken = default);
}