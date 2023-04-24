

namespace oneparalyzer.LeasingSystem.Feedbacks.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IFeedbacksRepository FeedbacksRepository { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
