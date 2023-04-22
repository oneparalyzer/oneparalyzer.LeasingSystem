using MediatR;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.FindByFullName;

public record GetByFullNameQuery(string FullName) : IRequest<IEnumerable<GetByFullNameDTO>>;
