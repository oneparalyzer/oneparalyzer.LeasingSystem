using AutoMapper;
using MediatR;
using oneparalyzer.LeasingSystem.Feedbacks.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.AggregateModels.FeedbackAggregate;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.Common;

namespace oneparalyzer.LeasingSystem.Feedbacks.Application.Feedbacks.Queries.GetAll;

public sealed class GetAllFeedbacksQueryHandler : IRequestHandler<GetAllFeedbacksQuery, ResultWithData<IEnumerable<GetAllFeedbacksDTO>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllFeedbacksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResultWithData<IEnumerable<GetAllFeedbacksDTO>>> Handle(GetAllFeedbacksQuery query, CancellationToken cancellationToken)
    {
        var result = new ResultWithData<IEnumerable<GetAllFeedbacksDTO>>();
        result.IsOk = true;

        IEnumerable<Feedback> feedbacks = _unitOfWork.FeedbacksRepository.GetAll();
        var feedbacksDTO = _mapper.Map<IEnumerable<GetAllFeedbacksDTO>>(feedbacks);

        result.Data = feedbacksDTO;
        return result;
    }
}
