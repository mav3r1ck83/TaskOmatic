using MediatR;

namespace TaskOmatic.Application.Commands.Tasks.CreateTask;

public record CreateTaskCommand(string Name, string Description, int? UserId) : IRequest<int>;
