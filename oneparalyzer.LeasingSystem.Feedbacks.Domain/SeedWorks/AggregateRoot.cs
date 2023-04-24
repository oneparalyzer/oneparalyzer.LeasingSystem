

namespace oneparalyzer.LeasingSystem.Feedbacks.Domain.SeedWorks;

public abstract class AggregateRoot<TId> : Entity<TId> where TId : notnull
{
    protected AggregateRoot(TId id) : base(id)
    {
    }
}
