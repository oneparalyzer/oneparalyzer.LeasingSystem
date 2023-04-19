using oneparalyzer.LeasingSystem.Customers.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities;

public sealed class Department : Entity<Guid>
{
    public Department(Guid id, string title) : base(id)
    {
        Title = title;
    }

    public string Title { get; private set; }
}
