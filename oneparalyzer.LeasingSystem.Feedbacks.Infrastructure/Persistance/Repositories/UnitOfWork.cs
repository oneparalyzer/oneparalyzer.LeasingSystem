

using oneparalyzer.LeasingSystem.Feedbacks.Application.Common.Interfaces;

namespace oneparalyzer.LeasingSystem.Feedbacks.Infrastructure.Persistance.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly FeedbacksDbContext _context;

    public UnitOfWork(FeedbacksDbContext context, IFeedbacksRepository feedbacksRepository)
    {
        _context = context;
        FeedbacksRepository = feedbacksRepository;

    }

    public IFeedbacksRepository FeedbacksRepository { get; }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
