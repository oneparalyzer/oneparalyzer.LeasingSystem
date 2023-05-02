using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.CustomerAggregate.Entities;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate;
using System.Reflection;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance;

public sealed class EmployeesDbContext : DbContext
{
    public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) : base(options)
    {
        
    }

    public DbSet<Office> Offices { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Region> Regions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
