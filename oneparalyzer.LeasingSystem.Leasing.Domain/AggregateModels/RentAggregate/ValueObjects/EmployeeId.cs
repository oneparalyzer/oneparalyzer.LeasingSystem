

using oneparalyzer.LeasingSystem.Leasing.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Leasing.Domain.AggregateModels.RentAggregate.ValueObjects;

public sealed class EmployeeId : ValueObject
{
    private EmployeeId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static EmployeeId Create(Guid value)
    {
        return new EmployeeId(value);
    }

    public static EmployeeId Create()
    {
        return new EmployeeId(Guid.NewGuid());
    }
}
