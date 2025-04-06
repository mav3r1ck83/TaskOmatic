using Microsoft.Extensions.DependencyInjection;
using TaskOmatic.Application.Interfaces.Repositories;
using TaskOmatic.Infrastructure.Repositories;

namespace TaskOmatic.Infrastructure.Repositories;

public static class RegistrationModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}