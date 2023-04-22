

using MediatR;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetAll;

public sealed record GetAllCutomersQuery() : IRequest<IEnumerable<GetAllCutomersDTO>>;
