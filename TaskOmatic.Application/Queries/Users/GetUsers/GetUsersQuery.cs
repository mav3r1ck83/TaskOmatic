using MediatR;
using TaskOmatic.Contracts.Responses;

namespace TaskOmatic.Application.Queries.Users.GetUsers;

public record GetUsersQuery : IRequest<GetUsersResponse>;
