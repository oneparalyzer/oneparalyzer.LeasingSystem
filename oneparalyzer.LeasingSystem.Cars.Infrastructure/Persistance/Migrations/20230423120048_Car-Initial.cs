using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oneparalyzer.LeasingSystem.Cars.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CarInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBrands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateConfirm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApprovedEmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarBrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_CarBrands_CarBrandId",
                        column: x => x.CarBrandId,
                        principalTable: "CarBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceListPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceRubles = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceListId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceListPositions_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    VinNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IssuingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EcologicalClass = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<long>(type: "bigint", nullable: false),
                    WeightWithoutLoad = table.Column<long>(type: "bigint", nullable: false),
                    CustomsRestrictions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomsDeclarationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApprovalCertificateNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    BodyNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FrameNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EnginePower = table.Column<long>(type: "bigint", nullable: false),
                    EngineCapacity = table.Column<long>(type: "bigint", nullable: false),
                    EngineType = table.Column<int>(type: "int", nullable: false),
                    ModelEngine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImportCountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Countries_ImportCountryId",
                        column: x => x.ImportCountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Seria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarDocuments_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarBrands_Title",
                table: "CarBrands",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarDocuments_CarId",
                table: "CarDocuments",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_CarBrandId",
                table: "CarModels",
                column: "CarBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_Title",
                table: "CarModels",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ApprovalCertificateNumber",
                table: "Cars",
                column: "ApprovalCertificateNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BodyNumber",
                table: "Cars",
                column: "BodyNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CustomsDeclarationNumber",
                table: "Cars",
                column: "CustomsDeclarationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineNumber",
                table: "Cars",
                column: "EngineNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FrameNumber",
                table: "Cars",
                column: "FrameNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ImportCountryId",
                table: "Cars",
                column: "ImportCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VinNumber",
                table: "Cars",
                column: "VinNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Title",
                table: "Countries",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceListPositions_CarId",
                table: "PriceListPositions",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceListPositions_PriceListId",
                table: "PriceListPositions",
                column: "PriceListId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_ApprovedEmployeeId",
                table: "PriceLists",
                column: "ApprovedEmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDocuments");

            migrationBuilder.DropTable(
                name: "PriceListPositions");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CarBrands");
        }
    }
}
