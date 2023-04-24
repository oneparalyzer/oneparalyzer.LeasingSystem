using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Feedbacks.Domain.AggregateModels.FeedbackAggregate;

namespace oneparalyzer.LeasingSystem.Feedbacks.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.UserId).IsRequired();
        builder.Property(x => x.Text).IsRequired().HasMaxLength(2048);
    }
}
