using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.CustomerAggregate.Entities;

public sealed class Street : Entity<StreetId>
{
    public Street(StreetId id, string title, City city) : base(id)
    {
        Title = title;
        City = city;
        CityId = city.Id;
    }

    private Street(StreetId id) : base(id)
    {
    }

    public string Title { get; private set; }
    public CityId CityId { get; private set; }
    public City City { get; private set; }

    public override string ToString()
    {
        return City.ToString() + " " + Title;
    }
}
