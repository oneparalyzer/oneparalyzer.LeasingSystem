using MediatR;

namespace oneparalyzer.LeasingSystem.Feedbacks.Application.Feedbacks.Queries.GetAll;

public record GetAllFeedbacksQuery() : IRequest<IEnumerable<GetAllFeedbacksDTO>>;
