using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class OfficeConfiguration : IEntityTypeConfiguration<Office>
{
    public void Configure(EntityTypeBuilder<Office> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
               .ValueGeneratedNever()
               .HasColumnName("Id")
               .HasConversion(
                   id => id.Value,
                   value => new OfficeId(value));

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.OwnsMany(x => x.DepartmentIds, departmentIdBuilder =>
        {
            departmentIdBuilder.ToTable("DepartmentIds");

            departmentIdBuilder
                .WithOwner()
                .HasForeignKey("OfficeId");

            departmentIdBuilder.HasKey("Id");

            departmentIdBuilder
                .Property(x => x.Value)
                .HasColumnName("DepartmentId")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Office.DepartmentIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(x => x.AddressId)
                   .ValueGeneratedNever()
                   .HasColumnName("AddressId")
                   .HasConversion(
                       id => id.Value,
                       value => new AddressId(value));

        builder.HasOne(x => x.Address).WithMany().HasForeignKey(x => x.AddressId);
    }
}
