

namespace oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IOfficesRepository OfficesRepository { get; }
    IDepartmentsRepository DepartmentsRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
