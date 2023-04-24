using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Cars.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.Entities;

public sealed class PriceListPosition : Entity<Guid>
{
    public PriceListPosition(Guid id, Guid carId, Price price) : base(id)
    {
        CarId = carId;
        Price = price;
    }

    private PriceListPosition(Guid id) : base(id)
    {
        
    }

    public Guid CarId { get; private set; }
    public Price Price { get; private set; }
}
