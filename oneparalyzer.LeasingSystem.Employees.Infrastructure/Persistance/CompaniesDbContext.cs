using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.CustomerAggregate.Entities;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.PostAggregate;
using oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance.EntityTypeConfigurations;
using System.Reflection;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance;

public sealed class CompaniesDbContext : DbContext
{
    public CompaniesDbContext(DbContextOptions<CompaniesDbContext> options) : base(options)
    {
        
    }

    public DbSet<Office> Offices { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Department> Departments { get; set; }
    //public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());   
    }
}
