using MediatR;
using TaskOmatic.Contracts.Dtos;
using TaskOmatic.Contracts.Responses;

namespace TaskOmatic.Application.Queries.Tasks.GetTaskById;

public record GetTaskByIdQuery(int Id) : IRequest<GetTaskByIdResponse>;
