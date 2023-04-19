using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Customers.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities;
using System.Reflection;

namespace oneparalyzer.LeasingSystem.Customers.Infrastructure.Persistance;

public sealed class CustomersDbContext : DbContext, ICustomersDbContext
{
    public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options)
    {

    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
