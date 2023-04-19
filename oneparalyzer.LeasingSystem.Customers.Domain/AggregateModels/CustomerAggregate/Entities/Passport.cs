using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Enums;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities;

public class Passport : Document
{
    private const DocumentType documentType = DocumentType.Passport;

    public Passport(
        Guid id, 
        DocumentIdentifier documentIdentifier, 
        DateTime issuingDate, 
        Department issuingDepartment) 
        : base(id, documentType, documentIdentifier, issuingDate, issuingDepartment, null)
    {
    }
}
