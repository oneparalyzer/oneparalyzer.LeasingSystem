using oneparalyzer.LeasingSystem.Feedbacks.Domain.AggregateModels.FeedbackAggregate;

namespace oneparalyzer.LeasingSystem.Feedbacks.Application.Common.Interfaces;

public interface IFeedbacksRepository : IRepository<Feedback>
{
    IEnumerable<Feedback> GetAll();
    Task CreateAsync(Feedback feedback, CancellationToken cancellationToken = default);
}
