using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities;

namespace oneparalyzer.LeasingSystem.Customers.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.IssuingDate).IsRequired();
        builder.Property(x => x.Type).IsRequired();

        builder.OwnsOne(x => x.DocumentIdentifier).Property(x => x.Seria).HasColumnName("Seria").IsRequired();
        builder.OwnsOne(x => x.DocumentIdentifier).Property(x => x.Number).HasColumnName("Number").IsRequired();
    }
}
