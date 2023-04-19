using oneparalyzer.LeasingSystem.Customers.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.ValueObjects;

public sealed class FullName : ValueObject
{
    public FullName(string name, string surname, string patronymic)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
    }

    public string Name { get; }
    public string Surname { get; }
    public string Patronymic { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Surname;
        yield return Patronymic;
    }
}
