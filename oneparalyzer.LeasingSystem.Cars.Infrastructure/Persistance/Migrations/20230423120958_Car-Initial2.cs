using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oneparalyzer.LeasingSystem.Cars.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CarInitial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PriceListPositions_CarId",
                table: "PriceListPositions");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListPositions_CarId",
                table: "PriceListPositions",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PriceListPositions_CarId",
                table: "PriceListPositions");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListPositions_CarId",
                table: "PriceListPositions",
                column: "CarId",
                unique: true);
        }
    }
}
