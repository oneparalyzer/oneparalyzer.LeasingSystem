using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.CustomerAggregate.Entities;

public sealed class City : Entity<CityId>
{
    public City(CityId id, string title, Region region) : base(id)
    {
        Title = title;
        Region = region;
    }

    private City(CityId id) : base(id)
    {
    }

    public string Title { get; private set; }
    public RegionId RegionId { get; private set; }
    public Region Region { get; private set; }
}
