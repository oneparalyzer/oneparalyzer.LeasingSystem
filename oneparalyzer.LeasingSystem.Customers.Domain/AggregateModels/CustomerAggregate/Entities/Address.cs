using oneparalyzer.LeasingSystem.Customers.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities;

public sealed class Address : Entity<Guid>
{
    public Address(Guid id, uint houseNumber, string? houseBuilding, string? apartmentNumber, Street street) : base(id)
    {
        HouseNumber = houseNumber;
        HouseBuilding = houseBuilding;
        ApartmentNumber = apartmentNumber;
        Street = street;
        StreetId = street.Id;
    }

    private Address(Guid id) : base(id)
    {
    }

    public uint HouseNumber { get; private set; }
    public string? HouseBuilding { get; private set; }
    public string? ApartmentNumber { get; private set; }
    public Guid StreetId { get; private set; }
    public Street Street { get; private set; }
}
