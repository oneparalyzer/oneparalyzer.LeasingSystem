

using MediatR;
using oneparalyzer.LeasingSystem.Customers.Domain.Common;

namespace oneparalyzer.LeasingSystem.Customers.Application.Customers.Queries.GetAll;

public sealed record GetAllCutomersQuery() : IRequest<ResultWithData<IEnumerable<GetAllCutomersDTO>>>;
