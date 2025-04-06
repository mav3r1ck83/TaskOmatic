using MediatR;

namespace TaskOmatic.Application.Commands.Tasks.DeleteTask;

public record DeleteTaskCommand(int Id) : IRequest<bool>;