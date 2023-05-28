

using oneparalyzer.LeasingSystem.Leasing.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Leasing.Domain.AggregateModels.RentAggregate.ValueObjects;

public sealed class ClientId : ValueObject
{
    private ClientId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static ClientId Create(Guid value)
    {
        return new ClientId(value);
    }

    public static ClientId Create()
    {
        return new ClientId(Guid.NewGuid());
    }
}
