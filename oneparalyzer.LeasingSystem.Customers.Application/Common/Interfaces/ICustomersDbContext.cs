using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate;

namespace oneparalyzer.LeasingSystem.Customers.Application.Common.Interfaces;

public interface ICustomersDbContext
{
    DbSet<Address> Addresses { get; set; }
    DbSet<City> Cities { get; set; }
    DbSet<Department> Departments { get; set; }
    DbSet<Document> Documents { get; set; }
    DbSet<Region> Regions { get; set; }
    DbSet<Street> Streets { get; set; }
    DbSet<Customer> Customers { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
