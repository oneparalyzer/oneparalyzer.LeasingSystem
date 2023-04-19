using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate;

namespace oneparalyzer.LeasingSystem.Customers.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.BirthDate).IsRequired();
        builder.Property(x => x.Gender).IsRequired();

        builder.OwnsOne(x => x.FullName).Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.OwnsOne(x => x.FullName).Property(x => x.Surname).HasColumnName("Surname").IsRequired();
        builder.OwnsOne(x => x.FullName).Property(x => x.Patronymic).HasColumnName("Patronymic").IsRequired();
    }
}
