using oneparalyzer.LeasingSystem.Cars.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities;

public sealed class CarBrand : Entity<Guid>
{
    public CarBrand(Guid id, string title) : base(id)
    {
        Title = title;
    }

    public string Title { get; private set; }
}
