using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.CustomerAggregate.Entities;

public sealed class Region : Entity<RegionId>
{
    public Region(RegionId id, string title) : base(id)
    {
        Title = title;
    }

    public string Title { get; private set; }

    public override string ToString()
    {
        return Title;
    }
}
