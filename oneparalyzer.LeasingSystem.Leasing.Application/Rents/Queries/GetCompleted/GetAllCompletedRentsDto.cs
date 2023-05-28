

namespace oneparalyzer.LeasingSystem.Leasing.Application.Rents.Queries.GetCompleted;

public class GetAllCompletedRentsDto
{
    public Guid RentId { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid ClientId { get; set; }
    public Guid PriceListPositionId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EstimatedCompletionDate { get; set; }
    public DateTime ActualCompletionDate { get; set; }
    public string ContractNumber { get; set; } = null!;
    public DateTime ContractDate { get; set; }
}
