using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using oneparalyzer.LeasingSystem.Customers.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Customers.Infrastructure.Persistance;

namespace oneparalyzer.LeasingSystem.Customers.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<ICustomersDbContext, CustomersDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}
