using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Enums;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Cars.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities;

public class CarDocument : Entity<Guid>
{
    public CarDocument(Guid id, DocumentIdentifier documentIdentifier, DateTime issuingDate, DocumentType type) : base(id)
    {
        DocumentIdentifier = documentIdentifier;
        IssuingDate = issuingDate;
        Type = type;
    }

    private CarDocument(Guid id) : base(id)
    {
    }

    public DocumentIdentifier DocumentIdentifier { get; private set; }
    public DateTime IssuingDate { get; private set; }
    public DocumentType Type { get; private set; }
}
