using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace oneparalyzer.LeasingSystem.Leasing.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
