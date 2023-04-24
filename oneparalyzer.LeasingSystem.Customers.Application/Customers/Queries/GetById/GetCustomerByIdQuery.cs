

using MediatR;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetById;

public record GetCustomerByIdQuery(Guid CustomerId) : IRequest<GetCustomerByIdDTO>;
