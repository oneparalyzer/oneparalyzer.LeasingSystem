using MediatR;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.Common;

namespace oneparalyzer.LeasingSystem.Feedbacks.Application.Feedbacks.Queries.GetAll;

public record GetAllFeedbacksQuery() : IRequest<ResultWithData<IEnumerable<GetAllFeedbacksDTO>>>;
