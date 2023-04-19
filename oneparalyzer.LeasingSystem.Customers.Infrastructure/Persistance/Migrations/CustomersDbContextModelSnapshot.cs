﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using oneparalyzer.LeasingSystem.Customers.Infrastructure.Persistance;

#nullable disable

namespace oneparalyzer.LeasingSystem.Customers.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(CustomersDbContext))]
    partial class CustomersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApartmentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseBuilding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("HouseNumber")
                        .HasColumnType("bigint");

                    b.Property<Guid>("StreetId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StreetId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("IssuingDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("IssuingDepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("IssuingDepartmentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.Street", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Customer", b =>
                {
                    b.HasOne("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.ValueObjects.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.Property<string>("Patronymic")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Patronymic");

                            b1.Property<string>("Surname")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Surname");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address");

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.Address", b =>
                {
                    b.HasOne("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.Street", "Street")
                        .WithMany()
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Street");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.City", b =>
                {
                    b.HasOne("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.Document", b =>
                {
                    b.HasOne("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Customer", null)
                        .WithMany("Documents")
                        .HasForeignKey("CustomerId");

                    b.HasOne("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.Department", "IssuingDepartment")
                        .WithMany()
                        .HasForeignKey("IssuingDepartmentId");

                    b.OwnsOne("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.ValueObjects.DocumentIdentifier", "DocumentIdentifier", b1 =>
                        {
                            b1.Property<Guid>("DocumentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Number");

                            b1.Property<string>("Seria")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Seria");

                            b1.HasKey("DocumentId");

                            b1.ToTable("Documents");

                            b1.WithOwner()
                                .HasForeignKey("DocumentId");
                        });

                    b.Navigation("DocumentIdentifier")
                        .IsRequired();

                    b.Navigation("IssuingDepartment");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.Street", b =>
                {
                    b.HasOne("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("oneparalyzer.LeasingSystem.Customers.Domain.AggregateModels.CustomerAggregate.Customer", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
