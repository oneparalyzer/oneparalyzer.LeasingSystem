using AutoMapper;
using MediatR;
using oneparalyzer.LeasingSystem.Feedbacks.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.AggregateModels.FeedbackAggregate;

namespace oneparalyzer.LeasingSystem.Feedbacks.Application.Feedbacks.Queries.GetAll;

public sealed class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbacksQuery, IEnumerable<GetAllFeedbacksDTO>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllFeedbacksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllFeedbacksDTO>> Handle(GetAllFeedbacksQuery query, CancellationToken cancellationToken)
    {
        IEnumerable<Feedback> feedbacks = _unitOfWork.FeedbacksRepository.GetAll();
        var feedbacksDTO = _mapper.Map<IEnumerable<GetAllFeedbacksDTO>>(feedbacks);
        return feedbacksDTO;
    }
}
