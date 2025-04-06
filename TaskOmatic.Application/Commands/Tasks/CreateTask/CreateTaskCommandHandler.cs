using MediatR;
using TaskOmatic.Application.Interfaces.Repositories;
using TaskOmatic.Domain.Entities;

namespace TaskOmatic.Application.Commands.Tasks.CreateTask;

public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
{
    private readonly ITaskRepository _taskRepository;

    public CreateTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskEntry
        {
            Name = request.Name,
            Description = request.Description,
            UserID = request.UserId,
            Created = DateTime.UtcNow
        };

        await _taskRepository.AddTask(task, cancellationToken);
        return task.Id;
    }
}