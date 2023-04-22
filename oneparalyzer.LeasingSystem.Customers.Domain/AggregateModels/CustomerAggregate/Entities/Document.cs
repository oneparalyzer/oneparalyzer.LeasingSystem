using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Enums;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Customers.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities;

public class Document : Entity<Guid>
{
    public Document(
        Guid id, 
        DocumentType documentType, 
        DocumentIdentifier documentIdentifier, 
        DateTime issuingDate, 
        Department? issuingDepartment, 
        string? comment) : base(id)
    {
        Id = id;
        Type = documentType;
        DocumentIdentifier = documentIdentifier;
        IssuingDate = issuingDate;
        Comment = comment;
        IssuingDepartment = issuingDepartment;
        if (issuingDepartment is not null)
        {
            IssuingDepartmentId = issuingDepartment.Id;
        }
    }

    private Document(Guid id) : base(id)
    {
    }

    public DocumentType Type { get; private set; }
    public DocumentIdentifier DocumentIdentifier { get; private set; }
    public DateTime IssuingDate { get; private set; }
    public Guid? IssuingDepartmentId { get; private set; }
    public Department? IssuingDepartment { get; private set; }
    public string? Comment { get; private set; }
}
