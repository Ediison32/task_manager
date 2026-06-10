

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using projectWeb.Application.Interfaces;
using projectWeb.Infrastructure.Repositories;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        // cadena para halar appsetion.json 
        var connetionsString = configuration.GetConnectionString("DefaultConnection");
        
        // pollemo 
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connetionsString, ServerVersion.AutoDetect(connetionsString)));

        services.AddScoped<ITaskRepository, TaskRepository>();
        return services;
    }


}

