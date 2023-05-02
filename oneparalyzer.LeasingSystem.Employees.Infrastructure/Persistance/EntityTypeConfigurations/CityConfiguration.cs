using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.CustomerAggregate.Entities;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasColumnName("Id")
               .HasConversion(
                    id => id.Value,
                    value => new CityId(value));

        builder.Property(x => x.RegionId)
                   .ValueGeneratedNever()
                   .HasColumnName("RegionId")
                   .HasConversion(
                       id => id.Value,
                       value => new RegionId(value));

        builder.Property(x => x.Title).IsRequired();

        builder.HasIndex(x => x.Title).IsUnique();

        builder.HasOne(x => x.Region).WithMany().HasForeignKey(x => x.RegionId);
    }
}
