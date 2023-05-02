using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.CustomerAggregate.Entities;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedNever()
               .HasColumnName("Id")
               .HasConversion(
                    id => id.Value,
                    value => new AddressId(value));

        builder.Property(x => x.StreetId)
                   .ValueGeneratedNever()
                   .HasColumnName("StreetId")
                   .HasConversion(
                       id => id.Value,
                       value => new StreetId(value));

        builder.Property(x => x.ApartmentNumber).IsRequired();

        builder.HasOne(x => x.Street).WithMany().HasForeignKey(x => x.StreetId);
    }
}
