using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using oneparalyzer.LeasingSystem.Leasing.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Leasing.Domain.AggregateModels.RentAggregate;
using System.Reflection;

namespace oneparalyzer.LeasingSystem.Leasing.Infrastructure.Persistance;

public sealed class RentDbContext : DbContext, IRentDbContext
{
    public RentDbContext(DbContextOptions<RentDbContext> options) : base(options) { }

    public DbSet<Rent> Rents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
