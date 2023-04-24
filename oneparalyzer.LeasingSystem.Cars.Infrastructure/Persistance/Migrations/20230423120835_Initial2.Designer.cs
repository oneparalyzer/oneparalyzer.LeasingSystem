﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using oneparalyzer.LeasingSystem.Cars.Infrastructure.Persistance;

#nullable disable

namespace oneparalyzer.LeasingSystem.Cars.Infrastructure.Migrations
{
    [DbContext(typeof(CarsDbContext))]
    [Migration("20230423120835_Initial2")]
    partial class Initial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApprovalCertificateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BodyNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("CarModelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomsDeclarationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CustomsRestrictions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EcologicalClass")
                        .HasColumnType("int");

                    b.Property<long>("EngineCapacity")
                        .HasColumnType("bigint");

                    b.Property<string>("EngineNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("EnginePower")
                        .HasColumnType("bigint");

                    b.Property<int>("EngineType")
                        .HasColumnType("int");

                    b.Property<string>("FrameNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("ImportCountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("IssuingDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("MaxWeight")
                        .HasColumnType("bigint");

                    b.Property<string>("ModelEngine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("VinNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<long>("WeightWithoutLoad")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ApprovalCertificateNumber")
                        .IsUnique();

                    b.HasIndex("BodyNumber")
                        .IsUnique();

                    b.HasIndex("CarModelId");

                    b.HasIndex("CustomsDeclarationNumber")
                        .IsUnique();

                    b.HasIndex("EngineNumber")
                        .IsUnique();

                    b.HasIndex("FrameNumber")
                        .IsUnique();

                    b.HasIndex("ImportCountryId");

                    b.HasIndex("VinNumber")
                        .IsUnique();

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities.CarBrand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("CarBrands");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities.CarDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("IssuingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarDocuments");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities.CarModel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarBrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CarBrandId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("CarModels");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.Entities.PriceListPosition", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PriceListId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.HasIndex("PriceListId");

                    b.ToTable("PriceListPositions");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.PriceList", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApprovedEmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateConfirm")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApprovedEmployeeId")
                        .IsUnique();

                    b.ToTable("PriceLists");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Car", b =>
                {
                    b.HasOne("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities.Country", "ImportCountry")
                        .WithMany()
                        .HasForeignKey("ImportCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");

                    b.Navigation("ImportCountry");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities.CarDocument", b =>
                {
                    b.HasOne("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Car", null)
                        .WithMany("Documents")
                        .HasForeignKey("CarId");

                    b.OwnsOne("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.ValueObjects.DocumentIdentifier", "DocumentIdentifier", b1 =>
                        {
                            b1.Property<Guid>("CarDocumentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Number");

                            b1.Property<string>("Seria")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Seria");

                            b1.HasKey("CarDocumentId");

                            b1.ToTable("CarDocuments");

                            b1.WithOwner()
                                .HasForeignKey("CarDocumentId");
                        });

                    b.Navigation("DocumentIdentifier")
                        .IsRequired();
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities.CarModel", b =>
                {
                    b.HasOne("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Entities.CarBrand", "CarBrand")
                        .WithMany()
                        .HasForeignKey("CarBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarBrand");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.Entities.PriceListPosition", b =>
                {
                    b.HasOne("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.Entities.PriceListPosition", null)
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.PriceList", null)
                        .WithMany("PriceListPositions")
                        .HasForeignKey("PriceListId");

                    b.OwnsOne("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("PriceListPositionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Rubles")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("PriceRubles");

                            b1.HasKey("PriceListPositionId");

                            b1.ToTable("PriceListPositions");

                            b1.WithOwner()
                                .HasForeignKey("PriceListPositionId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.CarAggregate.Car", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Cars.Domain.AggregateModels.PriceListAggregate.PriceList", b =>
                {
                    b.Navigation("PriceListPositions");
                });
#pragma warning restore 612, 618
        }
    }
}
