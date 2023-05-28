using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using oneparalyzer.LeasingSystem.Leasing.Domain.AggregateModels.RentAggregate;

namespace oneparalyzer.LeasingSystem.Leasing.Application.Common.Interfaces;

public interface IRentDbContext
{
    DbSet<Rent> Rents { get; set; }

    DatabaseFacade Database { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
