﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities;

namespace oneparalyzer.LeasingSystem.Customers.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Title).IsRequired();

        builder.HasIndex(x => x.Title).IsUnique();
    }
}
