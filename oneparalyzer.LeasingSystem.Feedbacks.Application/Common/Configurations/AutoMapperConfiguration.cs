

using AutoMapper;
using oneparalyzer.LeasingSystem.Feedbacks.Application.Feedbacks.Queries.GetAll;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.AggregateModels.FeedbackAggregate;

namespace oneparalyzer.LeasingSystem.Feedbacks.Application.Common.Configurations;

public sealed class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<Feedback, GetAllFeedbacksDTO>();
    }
}
