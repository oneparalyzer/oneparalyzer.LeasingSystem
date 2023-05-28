using MediatR;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.Common;

namespace oneparalyzer.LeasingSystem.Leasing.Application.Rents.Queries.GetCompleted;

public record class GetAllCompletedRentsQuery() : IRequest<ResultWithData<IEnumerable<GetAllCompletedRentsDto>>>;
