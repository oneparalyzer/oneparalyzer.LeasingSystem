using MediatR;
using oneparalyzer.LeasingSystem.Customers.Domain.Common;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Commands.RemoveById;

public record RemoveByIdCustomerCommand(Guid CustomerId) : IRequest<Result>;
