using MediatR;
using TaskOmatic.Application.Interfaces.Repositories;
using TaskOmatic.Application.Commands.Tasks.UpdateTask;

namespace TaskOmatic.Application.Commands.Tasks.UpdateTask;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
{
    private readonly ITaskRepository _taskRepository;

    public UpdateTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetTaskById(request.Id, cancellationToken);

        task.Name = request.Name;
        task.Description = request.Description;
        task.UserID = request.UserId;

        await _taskRepository.UpdateTask(task, cancellationToken);
        return Unit.Value;
    }
}