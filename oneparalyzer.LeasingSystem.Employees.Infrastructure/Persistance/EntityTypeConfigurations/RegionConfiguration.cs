using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.CustomerAggregate.Entities;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasColumnName("Id")
               .HasConversion(
                    id => id.Value,
                    value => new RegionId(value));


        builder.Property(x => x.Title).IsRequired();

        builder.HasIndex(x => x.Title).IsUnique();
    }
}
