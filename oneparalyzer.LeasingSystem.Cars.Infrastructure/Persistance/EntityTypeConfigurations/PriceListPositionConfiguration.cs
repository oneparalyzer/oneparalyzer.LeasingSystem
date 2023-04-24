using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.Entities;

namespace oneparalyzer.LeasingSystem.Cars.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class PriceListPositionConfiguration : IEntityTypeConfiguration<PriceListPosition>
{
    public void Configure(EntityTypeBuilder<PriceListPosition> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.CarId).IsRequired();

        builder.OwnsOne(x => x.Price).Property(x => x.Rubles).IsRequired().HasColumnName("PriceRubles");

        builder.HasIndex(x => x.CarId).IsUnique();
    }
}
