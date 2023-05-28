using oneparalyzer.LeasingSystem.Employees.Application.Common.Interfaces;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly CompaniesDbContext _context;

    public UnitOfWork(
        CompaniesDbContext context, 
        IOfficesRepository officesRepository,
        IDepartmentsRepository departmentsRepository)
    {
        _context = context;
        OfficesRepository = officesRepository;
        DepartmentsRepository = departmentsRepository;
    }

    public IOfficesRepository OfficesRepository { get; }
    public IDepartmentsRepository DepartmentsRepository { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
