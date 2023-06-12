using Application.MVC.Commons.Interfaces;
using Infrastructure.MVC.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.MVC;

public static class ConfigurationService
{
    public static IServiceCollection AddInfrstructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("DbConnect"));
        });

        return services;
    }
}
