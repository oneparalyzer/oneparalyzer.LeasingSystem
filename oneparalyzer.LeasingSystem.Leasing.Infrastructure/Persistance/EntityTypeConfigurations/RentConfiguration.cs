using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Leasing.Domain.AggregateModels.RentAggregate;
using oneparalyzer.LeasingSystem.Leasing.Domain.AggregateModels.RentAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Leasing.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class RentConfiguration : IEntityTypeConfiguration<Rent>
{
    public void Configure(EntityTypeBuilder<Rent> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasColumnName("Id")
            .HasConversion(
                id => id.Value,
                value => RentId.Create(value));

        builder.OwnsOne(x => x.PriceListPositionId).Property(x => x.Value).IsRequired();
        builder.OwnsOne(x => x.ClientId).Property(x => x.Value).IsRequired();
        builder.OwnsOne(x => x.EmployeeId).Property(x => x.Value).IsRequired();

        builder.Property(x => x.StartDate).IsRequired();
        builder.Property(x => x.EstimatedCompletionDate).IsRequired();
        builder.Property(x => x.ContractDate).IsRequired();
        builder.Property(x => x.ContractDate).IsRequired();

        builder.HasIndex(x => x.ContractNumber).IsUnique();
    }
}
