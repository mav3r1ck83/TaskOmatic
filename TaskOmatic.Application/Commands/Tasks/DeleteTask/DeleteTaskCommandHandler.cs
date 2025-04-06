using MediatR;
using TaskOmatic.Application.Commands.Tasks.DeleteTask;
using TaskOmatic.Application.Interfaces.Repositories;

namespace TaskOmatic.Application.Commands.Tasks.DeleteTask;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        await _taskRepository.DeleteTask(request.Id, cancellationToken);
        return true;
    }
}