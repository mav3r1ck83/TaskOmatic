using Mapster;
using MediatR;
using TaskOmatic.Application.Interfaces.Repositories;
using TaskOmatic.Contracts.Responses;

namespace TaskOmatic.Application.Queries.Users.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUsersResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetUsers(cancellationToken);
        return users.Adapt<GetUsersResponse>();
    }
}