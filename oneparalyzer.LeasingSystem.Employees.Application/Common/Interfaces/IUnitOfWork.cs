

namespace oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IOfficesRepository OfficesRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
