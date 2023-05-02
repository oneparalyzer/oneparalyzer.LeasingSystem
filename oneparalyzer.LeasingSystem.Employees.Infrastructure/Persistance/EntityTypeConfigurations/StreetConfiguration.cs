using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.CustomerAggregate.Entities;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class StreetConfiguration : IEntityTypeConfiguration<Street>
{
    public void Configure(EntityTypeBuilder<Street> builder)
    {
        builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasColumnName("Id")
               .HasConversion(
                    id => id.Value,
                    value => new StreetId(value));

        builder.Property(x => x.CityId)
                   .ValueGeneratedNever()
                   .HasColumnName("CityId")
                   .HasConversion(
                       id => id.Value,
                       value => new CityId(value));

        builder.Property(x => x.Title).IsRequired();

        builder.HasIndex(x => x.Title).IsUnique();

        builder.HasOne(x => x.City).WithMany().HasForeignKey(x => x.CityId);
    }
}
