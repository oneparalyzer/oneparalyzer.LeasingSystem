using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities;
using System.Reflection;

namespace oneparalyzer.LeasingSystem.Cars.Infrastructure.Persistance;

public sealed class CarsDbContext : DbContext
{
    public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
    {
        
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<CarBrand> CarBrands { get; set; }
    public DbSet<CarDocument> CarDocuments { get; set; }
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
