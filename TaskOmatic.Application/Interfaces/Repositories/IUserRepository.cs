using TaskOmatic.Domain.Entities;

namespace TaskOmatic.Application.Interfaces.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetUsers(CancellationToken cancellationToken = default);
}