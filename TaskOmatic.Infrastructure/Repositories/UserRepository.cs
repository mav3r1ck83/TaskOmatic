using Microsoft.EntityFrameworkCore;
using TaskOmatic.Application.Interfaces.Repositories;
using TaskOmatic.Domain.Entities;

namespace TaskOmatic.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TaskOmaticDbContext _dbContext;

    public UserRepository(TaskOmaticDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<User>> GetUsers(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.ToListAsync(cancellationToken);
    }
}