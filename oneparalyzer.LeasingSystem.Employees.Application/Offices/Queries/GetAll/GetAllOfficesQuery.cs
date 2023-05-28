using MediatR;
using oneparalyzer.LeasingSystem.Employees.Domain.Common;

namespace oneparalyzer.LeasingSystem.Employees.Application.Offices.Queries.GetAll;

public record GetAllOfficesQuery() : IRequest<ResultWithData<IEnumerable<GetAllOfficesDTO>>>;
