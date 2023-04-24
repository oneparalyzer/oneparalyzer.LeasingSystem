using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Feedbacks.Application.Common.Interfaces;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.AggregateModels.FeedbackAggregate;

namespace oneparalyzer.LeasingSystem.Feedbacks.Infrastructure.Persistance.Repositories;

public class FeedbacksRepository : IFeedbacksRepository
{
    private readonly FeedbacksDbContext _context;

    public FeedbacksRepository(FeedbacksDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Feedback feedback, CancellationToken cancellationToken = default)
    {
        await _context.AddAsync(feedback, cancellationToken);
    }

    public IEnumerable<Feedback> GetAll()
    {
        return _context.Feedbacks.Include(x => x.Feedbacks).Where(x => x.IsRoot);
    }
}
