using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.Entities;

namespace oneparalyzer.LeasingSystem.Cars.Application.Common.Interfaces;

public interface ICarsDbContext
{
    DbSet<Car> Cars { get; set; }
    DbSet<CarBrand> CarBrands { get; set; }
    DbSet<CarDocument> CarDocuments { get; set; }
    DbSet<CarModel> CarModels { get; set; }
    DbSet<Country> Countries { get; set; }
    DbSet<PriceList> PriceLists { get; set; }
    DbSet<PriceListPosition> PriceListPositions { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
