using Mapster;
using MediatR;
using TaskOmatic.Application.Interfaces.Repositories;
using TaskOmatic.Contracts.Responses;

namespace TaskOmatic.Application.Queries.Tasks.GetTaskById;

public class GetTasksByIdHandler : IRequestHandler<GetTaskByIdQuery, GetTaskByIdResponse>
{
    private readonly ITaskRepository _taskRepository;

    public GetTasksByIdHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<GetTaskByIdResponse> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.GetTaskById(request.Id, cancellationToken);
        return task.Adapt<GetTaskByIdResponse>();
    }
}