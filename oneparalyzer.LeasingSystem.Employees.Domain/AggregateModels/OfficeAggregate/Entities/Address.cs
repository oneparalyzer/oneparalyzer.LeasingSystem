using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.CustomerAggregate.Entities;

public sealed class Address : Entity<AddressId>
{
    public Address(AddressId id, uint houseNumber, string? houseBuilding, Street street) : base(id)
    {
        HouseNumber = houseNumber;
        HouseBuilding = houseBuilding;
        Street = street;
        StreetId = street.Id;
    }

    private Address(AddressId id) : base(id)
    {
    }

    public uint HouseNumber { get; private set; }
    public string? HouseBuilding { get; private set; }
    public StreetId StreetId { get; private set; }
    public Street Street { get; private set; }

    public override string ToString()
    {
        return Street.ToString() + " " + HouseNumber + " " + HouseBuilding;
    }
}
