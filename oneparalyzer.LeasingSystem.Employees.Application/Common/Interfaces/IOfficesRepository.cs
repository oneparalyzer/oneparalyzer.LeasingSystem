using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;

public interface IOfficesRepository : IRepository<Office, OfficeId>
{
    Task<Result> CreateAsync(Office office, CancellationToken cancellationToken = default);
    Task<ResultWithData<IEnumerable<Office>>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Result> RemoveByIdAsync(OfficeId officeId, CancellationToken cancellationToken = default);
}
