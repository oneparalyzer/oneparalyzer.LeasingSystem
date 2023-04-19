using oneparalyzer.LeasingSystem.Customers.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities;

public sealed class Street : Entity<Guid>
{
    public Street(Guid id, string title, City city) : base(id)
    {
        Title = title;
        City = city;
        CityId = city.Id;
    }

    private Street(Guid id) : base(id)
    {
    }

    public string Title { get; private set; }
    public Guid CityId { get; private set; }
    public City City { get; private set; }
}
