using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using oneparalyzer.LeasingSystem.Leasing.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Leasing.Infrastructure.Persistance;

namespace oneparalyzer.LeasingSystem.Leasing.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<IRentDbContext, RentDbContext>(options => options.UseSqlServer(connectionString));
        return services;
    }
}
