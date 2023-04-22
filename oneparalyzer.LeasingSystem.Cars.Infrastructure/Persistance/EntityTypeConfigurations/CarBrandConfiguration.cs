﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities;

namespace oneparalyzer.LeasingSystem.Cars.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class CarBrandConfiguration : IEntityTypeConfiguration<CarBrand>
{
    public void Configure(EntityTypeBuilder<CarBrand> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.Title).IsRequired();

        builder.HasIndex(x => x.Title).IsUnique();
    }
}
