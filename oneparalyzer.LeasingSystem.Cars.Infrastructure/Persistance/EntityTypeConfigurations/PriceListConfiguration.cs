using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate;

namespace oneparalyzer.LeasingSystem.Cars.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class PriceListConfiguration : IEntityTypeConfiguration<PriceList>
{
    public void Configure(EntityTypeBuilder<PriceList> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.DateConfirm).IsRequired();
        builder.Property(x => x.ApprovedEmployeeId).IsRequired();

        builder.HasMany(x => x.PriceListPositions).WithOne();

        builder.HasIndex(x => x.ApprovedEmployeeId).IsUnique();
    }
}
