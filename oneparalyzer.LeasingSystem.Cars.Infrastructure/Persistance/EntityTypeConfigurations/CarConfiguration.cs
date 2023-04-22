using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate;

namespace oneparalyzer.LeasingSystem.Cars.Infrastructure.Persistance.EntityTypeConfigurations;

public sealed class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.Property(x => x.EngineType).IsRequired();
        builder.Property(x => x.EngineCapacity).IsRequired();
        builder.Property(x => x.ApprovalCertificateNumber).IsRequired();
        builder.Property(x => x.BodyNumber).IsRequired();
        builder.Property(x => x.Color).IsRequired();
        builder.Property(x => x.CustomsDeclarationNumber).IsRequired();
        builder.Property(x => x.CustomsRestrictions).IsRequired();
        builder.Property(x => x.EcologicalClass).IsRequired();
        builder.Property(x => x.EngineCapacity).IsRequired();
        builder.Property(x => x.EngineNumber).IsRequired();
        builder.Property(x => x.EnginePower).IsRequired();
        builder.Property(x => x.EngineType).IsRequired();

        builder.HasIndex(x => x.EngineNumber).IsUnique();
        builder.HasIndex(x => x.ApprovalCertificateNumber).IsUnique();
        builder.HasIndex(x => x.VinNumber).IsUnique();
        builder.HasIndex(x => x.BodyNumber).IsUnique();
        builder.HasIndex(x => x.FrameNumber).IsUnique();
        builder.HasIndex(x => x.CustomsDeclarationNumber).IsUnique();
    }
}
