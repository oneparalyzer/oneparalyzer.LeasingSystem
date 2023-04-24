using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using oneparalyzer.LeasingSystem.Feedbacks.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Feedbacks.Infrastructure.Persistance;
using oneparalyzer.LeasingSystem.Feedbacks.Infrastructure.Persistance.Repositories;

namespace oneparalyzer.LeasingSystem.Feedbacks.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<FeedbacksDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IFeedbacksRepository, FeedbacksRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
