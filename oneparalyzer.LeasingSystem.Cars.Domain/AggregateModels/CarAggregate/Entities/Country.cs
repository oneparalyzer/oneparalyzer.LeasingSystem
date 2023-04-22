using oneparalyzer.LeasingSystem.Cars.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities;

public sealed class Country : Entity<Guid>
{
    public Country(Guid id, string title) : base(id)
    {
        Title = title;
    }

    public string Title { get; private set; }
}
