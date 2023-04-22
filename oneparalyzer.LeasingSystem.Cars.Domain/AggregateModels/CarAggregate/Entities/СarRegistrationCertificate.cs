using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Enums;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities;

public sealed class СarRegistrationCertificate : CarDocument
{
    private const DocumentType RegistrationCertificate = DocumentType.СarRegistrationCertificate;

    public СarRegistrationCertificate(
        Guid id,
        DocumentIdentifier documentIdentifier,
        DateTime issuingDate)
        : base(id, documentIdentifier, issuingDate, RegistrationCertificate)
    {

    }
}
