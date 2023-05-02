using oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly EmployeesDbContext _context;

    public UnitOfWork(EmployeesDbContext context, IOfficesRepository officesRepository)
    {
        _context = context;
        OfficesRepository = officesRepository;
    }

    public IOfficesRepository OfficesRepository { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
