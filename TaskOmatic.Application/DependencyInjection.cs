using System.Reflection;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using TaskOmatic.Application.Mappings;

namespace TaskOmatic.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cf =>
        {
            cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            
        });
        
        
        MappingConfig.Configure();
        var config = TypeAdapterConfig.GlobalSettings; 
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);
        
        return services;
    }
}