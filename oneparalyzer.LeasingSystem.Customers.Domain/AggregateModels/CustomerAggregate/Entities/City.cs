using oneparalyzer.LeasingSystem.Customers.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities;

public sealed class City : Entity<Guid>
{
    public City(Guid id, string title, Region region) : base(id)
    {
        Title = title;
        Region = region;
    }

    private City(Guid id) : base(id)
    {
    }

    public string Title { get; private set; }
    public Guid RegionId { get; private set; }
    public Region Region { get; private set; }
}
