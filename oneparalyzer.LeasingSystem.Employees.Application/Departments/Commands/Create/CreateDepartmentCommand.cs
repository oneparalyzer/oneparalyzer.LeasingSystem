using MediatR;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Application.Departments.Commands.Create;

public record CreateDepartmentCommand(
    string Title, 
    Guid OfficeId) : IRequest<Result>;
