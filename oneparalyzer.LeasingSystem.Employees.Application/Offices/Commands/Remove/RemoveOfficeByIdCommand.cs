using MediatR;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Application.Offices.Commands.Remove;

public record RemoveOfficeByIdCommand(
    Guid OfficeId) : IRequest<Result>;