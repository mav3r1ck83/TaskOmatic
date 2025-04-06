using MediatR;
using TaskOmatic.Contracts.Responses;

namespace TaskOmatic.Application.Queries.Tasks.GetTask;

public record GetTasksQuery() : IRequest<GetTasksResponse>;
