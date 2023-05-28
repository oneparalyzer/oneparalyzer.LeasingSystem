using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using oneparalyzer.LeasingSystem.Employees.Application.Offices.Commands.Create;
using System.Reflection;

namespace oneparalyzer.LeasingSystem.Employees.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidation();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }

    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddSingleton<IValidator<CreateOfficeCommand>, CreateOfficeCommandValidator>();
        return services;
    }
}
