using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.DepartmentAggregate.ValueObjects;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.OfficeAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasColumnName("Id")
            .HasConversion(
                id => id.Value,
                value => new DepartmentId(value));

        builder.Property(x => x.OfficeId)
            .ValueGeneratedNever()
            .HasColumnName("OfficeId")
            .IsRequired()
            .HasConversion(
                id => id.Value,
                value => new OfficeId(value));

        builder.OwnsMany(x => x.PostIds, postIdBuilder =>
        {
            postIdBuilder.ToTable("PostIds");

            postIdBuilder
                .WithOwner()
                .HasForeignKey("DepartmentId");

            postIdBuilder.HasKey("Id");

            postIdBuilder
                .Property(x => x.Value)
                .HasColumnName("PostIds")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Department.PostIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);


        builder.Property(x => x.Title).IsRequired();

        builder.HasIndex(x => x.Title).IsUnique();
    }
}
