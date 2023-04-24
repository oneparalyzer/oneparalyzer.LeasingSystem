using MediatR;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.FindByFullName;

public record GetCustomerByFullNameQuery(string FullName) : IRequest<IEnumerable<GetCustomerByFullNameDTO>>;
