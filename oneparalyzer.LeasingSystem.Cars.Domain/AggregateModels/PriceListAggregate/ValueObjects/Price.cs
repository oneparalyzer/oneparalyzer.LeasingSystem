using oneparalyzer.LeasingSystem.Cars.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.ValueObjects;

public sealed class Price : ValueObject
{
    public Price(decimal rubles)
    {
        Rubles = rubles;
    }

    public decimal Rubles { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Rubles;
    }
}
