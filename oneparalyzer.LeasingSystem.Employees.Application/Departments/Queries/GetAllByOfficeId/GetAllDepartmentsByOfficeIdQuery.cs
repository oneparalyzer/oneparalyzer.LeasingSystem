using MediatR;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Application.Departments.Queries.GetAllByOfficeId;

public record GetAllDepartmentsByOfficeIdQuery(
    Guid OfficeId) : IRequest<ResultWithData<IEnumerable<GetAllDepartmentsByOfficeIdDTO>>>;
