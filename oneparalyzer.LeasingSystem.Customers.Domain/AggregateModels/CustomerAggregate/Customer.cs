using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Enums;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Customers.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate;

public sealed class Customer : AggregateRoot<Guid>
{
    private readonly List<Document> _documents = new();

    public Customer(
        Guid id,
        FullName fullName,
        DateTime birthDate,
        Gender gender,
        Address address,
        Passport passport,
        DriverLicense driverLicense) : base(id)
    {
        FullName = fullName;
        BirthDate = birthDate;
        Gender = gender;
        Address = address;
        AddressId = address.Id;
        _documents.Add(passport);
        _documents.Add(driverLicense);
    }

    private Customer(Guid id) : base(id)
    {
    }

    public Guid? UserId { get; private set; }
    public FullName FullName { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Gender Gender { get; private set; }
    public Guid AddressId { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyCollection<Document> Documents => _documents.AsReadOnly();

    public void BindUser(Guid userId)
    {
        UserId = userId;
    }
}
