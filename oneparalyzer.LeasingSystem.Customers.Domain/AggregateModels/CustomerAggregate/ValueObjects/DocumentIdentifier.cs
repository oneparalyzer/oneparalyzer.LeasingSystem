using oneparalyzer.LeasingSystem.Customers.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.ValueObjects;

public sealed class DocumentIdentifier : ValueObject
{
    public DocumentIdentifier(string seria, string number)
    {
        Seria = seria;
        Number = number;
    }

    public string Seria { get; }
    public string Number { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Seria; 
        yield return Number;
    }
}
