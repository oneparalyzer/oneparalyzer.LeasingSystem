using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Enums;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities;

public sealed class CarInsurance : CarDocument
{
    private const DocumentType Insurance = DocumentType.CarInsurance;

    public СarRegistrationCertificate(
        Guid id,
        DocumentIdentifier documentIdentifier,
        DateTime issuingDate)
        : base(id, documentIdentifier, issuingDate, Insurance)
    {

    }
}
