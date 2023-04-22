using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Enums;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities;

public sealed class CarPassport : CarDocument
{
    private const DocumentType Passport = DocumentType.СarPassport;

    public CarPassport(
        Guid id,
        DocumentIdentifier documentIdentifier,
        DateTime issuingDate)
        : base(id, documentIdentifier, issuingDate, Passport)
    {

    }
}
