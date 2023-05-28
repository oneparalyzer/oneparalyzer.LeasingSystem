using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;

public interface IDepartmentsRepository : IRepository<Department, DepartmentId>
{
    Task<Result> CreateAsync(Department department, CancellationToken cancellationToken = default);
    Task<ResultWithData<IEnumerable<Department>>> GetAllByOfficeIdAsync(OfficeId officeId, CancellationToken cancellationToken = default);
    Task<Result> RemoveByIdAsync(DepartmentId departmentId, CancellationToken cancellationToken = default);
    Task<ResultWithData<Department>> GetByIdAsync(DepartmentId departmentId, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(Department department, CancellationToken cancellationToken = default);
}
