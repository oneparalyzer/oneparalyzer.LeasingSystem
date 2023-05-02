using MediatR;
using oneparalyzer.LeasingSystem.Customers.Domain.Common;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetById;

public record GetCustomerByIdQuery(Guid CustomerId) : IRequest<ResultWithData<GetCustomerByIdDTO>>;
