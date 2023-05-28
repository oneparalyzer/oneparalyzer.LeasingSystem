

using oneparalyzer.LeasingSystem.Leasing.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Leasing.Domain.AggregateModels.RentAggregate.ValueObjects;

public sealed class PriceListPositionId : ValueObject
{
    private PriceListPositionId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static PriceListPositionId Create(Guid value)
    {
        return new PriceListPositionId(value);
    }

    public static PriceListPositionId Create()
    {
        return new PriceListPositionId(Guid.NewGuid());
    }
}
