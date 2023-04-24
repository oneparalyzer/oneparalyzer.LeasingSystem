using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using oneparalyzer.LeasingSystem.Cars.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Cars.Infrastructure.Persistance;

namespace oneparalyzer.LeasingSystem.Cars.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ICarsDbContext, CarsDbContext>(options => options.UseSqlServer(connectionString));
        return services;
    }
}
