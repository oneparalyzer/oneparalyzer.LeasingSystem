using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace oneparalyzer.LeasingSystem.Cars.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
