using TaskOmatic.Contracts.Dtos;

namespace TaskOmatic.Contracts.Responses;

public record GetTasksResponse(List<TaskDto>  TasksDtos);