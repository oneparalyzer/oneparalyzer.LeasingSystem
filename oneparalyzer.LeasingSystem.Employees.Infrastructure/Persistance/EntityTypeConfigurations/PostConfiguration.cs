using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.PostAggregate;
using oneparalyzer.LeasingSystem.Employees.Domain.AggregateModels.PostAggregate.ValueObjects;

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class PostConfiguration //: IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasColumnName("Id")
            .HasConversion(
                id => id.Value,
                value => new PostId(value));

        builder.OwnsMany(x => x.DepartmentIds, postIdBuilder =>
        {
            postIdBuilder.ToTable("PostDepartmentIds");

            postIdBuilder
                .WithOwner()
                .HasForeignKey("PostId");

            postIdBuilder.HasKey("Id");

            postIdBuilder
                .Property(x => x.Value)
                .HasColumnName("DepartmentId")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Post.DepartmentIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);


        builder.OwnsMany(x => x.EmployeeIds, postIdBuilder =>
        {
            postIdBuilder.ToTable("EmployeeIds");

            postIdBuilder
                .WithOwner()
                .HasForeignKey("PostId");

            postIdBuilder.HasKey("Id");

            postIdBuilder
                .Property(x => x.Value)
                .HasColumnName("EmployeeIds")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Post.EmployeeIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Property(x => x.Title).IsRequired();

        builder.HasIndex(x => x.Title).IsUnique();
    }
}
