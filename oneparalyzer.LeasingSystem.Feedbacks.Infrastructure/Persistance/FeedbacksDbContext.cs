using Microsoft.EntityFrameworkCore;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.AggregateModels.FeedbackAggregate;
using System.Reflection;

namespace oneparalyzer.LeasingSystem.Feedbacks.Infrastructure.Persistance;

public sealed class FeedbacksDbContext : DbContext
{
    public FeedbacksDbContext(DbContextOptions<FeedbacksDbContext> options) : base(options)
    {
        
    }

    public DbSet<Feedback> Feedbacks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
