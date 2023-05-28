using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance;
using oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance.Repositories;
using System.Reflection;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddPersistance(configuration);
        services.AddRepositories();
        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<CompaniesDbContext>(options => 
            options.UseSqlServer(connectionString));
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IOfficesRepository, OfficesRepository>();
        services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
