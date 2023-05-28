using oneparalyzer.LeasingSystem.Leasing.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Leasing.Domain.AggregateModels.RentAggregate.ValueObjects;

public sealed class RentId : ValueObject
{
    private RentId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static RentId Create(Guid value)
    {
        return new RentId(value);
    }

    public static RentId Create()
    {
        return new RentId(Guid.NewGuid());
    }
}
