using MediatR;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.Common;
using oneparalyzer.LeasingSystem.Leasing.Domain.AggregateModels.RentAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Leasing.Application.Rents.Commands.Create;

public record CreateRentCommand(
    Guid EmployeeId,
    Guid ClientId,
    Guid PriceListPositionId,
    DateTime EstimatedCompletionDate,
    string ContractNumber,
    DateTime ContractDate) : IRequest<Result>;
