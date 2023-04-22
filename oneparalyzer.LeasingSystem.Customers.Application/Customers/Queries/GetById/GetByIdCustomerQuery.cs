

using MediatR;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetById;

public record GetByIdCustomerQuery(Guid CustomerId) : IRequest<GetByIdCustomerDTO>;
