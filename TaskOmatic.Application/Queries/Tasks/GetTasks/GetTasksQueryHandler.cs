using Mapster;
using MediatR;
using TaskOmatic.Application.Interfaces.Repositories;
using TaskOmatic.Contracts.Dtos;
using TaskOmatic.Contracts.Responses;

namespace TaskOmatic.Application.Queries.Tasks.GetTask;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, GetTasksResponse>
{
    private readonly ITaskRepository _taskRepository;

    public GetTasksQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<GetTasksResponse> Handle(GetTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetTasks(cancellationToken);
        var taskDtos = tasks.Adapt<List<TaskDto>>(); 
        return new GetTasksResponse(taskDtos); 
    }
}