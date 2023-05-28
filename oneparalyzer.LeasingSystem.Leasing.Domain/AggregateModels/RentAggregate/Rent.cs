using oneparalyzer.LeasingSystem.Feedbacks.Domain.Common;
using oneparalyzer.LeasingSystem.Leasing.Domain.AggregateModels.RentAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Leasing.Domain.SeedWorks;

namespace oneparalyzer.LeasingSystem.Leasing.Domain.AggregateModels.RentAggregate;

public sealed class Rent : AggregateRoot<RentId>
{
    private Rent(RentId id) : base(id) { }

    public Rent(
        RentId rentId, 
        EmployeeId employeeId, 
        ClientId clientId, 
        PriceListPositionId priceListPositionId, 
        DateTime estimatedCompletionDate, 
        string contractNumber, 
        DateTime contractDate) : base(rentId)
    {
        EmployeeId = employeeId;
        ClientId = clientId;
        PriceListPositionId = priceListPositionId;
        EstimatedCompletionDate = estimatedCompletionDate;
        ContractNumber = contractNumber;
        ContractDate = contractDate;
    }

    public EmployeeId EmployeeId { get; private set; }
    public ClientId ClientId { get; private set; }
    public PriceListPositionId PriceListPositionId { get; private set; }
    public DateTime StartDate { get; private set; } = DateTime.UtcNow;
    public DateTime EstimatedCompletionDate { get; private set; }
    public DateTime? ActualCompletionDate { get; private set; }
    public string ContractNumber { get; private set; }
    public DateTime ContractDate { get; private set; }

    public bool IsCompleted()
    {
        return ActualCompletionDate is not null;
    }

    public Result Complete()
    {
        var result = new Result();
        
        if (IsCompleted())
        {
            result.AddError("Аренда уже завершена.");
            return result;
        }

        ActualCompletionDate = DateTime.UtcNow;
        return result;
    }
}
