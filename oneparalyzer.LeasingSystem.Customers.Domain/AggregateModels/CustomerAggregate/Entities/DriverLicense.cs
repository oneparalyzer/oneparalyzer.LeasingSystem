using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Enums;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities;

public sealed class DriverLicense : Document
{
    private const DocumentType documentType = DocumentType.DriverLicense;

    public DriverLicense(
        Guid id,
        DocumentIdentifier documentIdentifier,
        DateTime issuingDate,
        string? comment) : base(id, documentType, documentIdentifier, issuingDate, null, comment)
    {
    }
}
