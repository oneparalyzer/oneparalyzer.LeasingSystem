using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities;

namespace oneparalyzer.LeasingSystem.Cars.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class CarDocumentConfiguration : IEntityTypeConfiguration<CarDocument>
{
    public void Configure(EntityTypeBuilder<CarDocument> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Type).IsRequired();
        builder.Property(x => x.IssuingDate).IsRequired();
        
        builder.OwnsOne(x => x.DocumentIdentifier).Property(x => x.Seria).IsRequired().HasColumnName("Seria");
        builder.OwnsOne(x => x.DocumentIdentifier).Property(x => x.Number).IsRequired().HasColumnName("Number");
    }
}
