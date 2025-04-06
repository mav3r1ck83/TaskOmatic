using MediatR;

namespace TaskOmatic.Application.Commands.Tasks.UpdateTask;

public record UpdateTaskCommand(int Id, string Name, string Description, int? UserId) : IRequest<Unit>;