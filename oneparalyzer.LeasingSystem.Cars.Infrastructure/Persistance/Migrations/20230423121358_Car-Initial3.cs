using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oneparalyzer.LeasingSystem.Cars.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CarInitial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceListPositions_PriceListPositions_CarId",
                table: "PriceListPositions");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListPositions_Cars_CarId",
                table: "PriceListPositions",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceListPositions_Cars_CarId",
                table: "PriceListPositions");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceListPositions_PriceListPositions_CarId",
                table: "PriceListPositions",
                column: "CarId",
                principalTable: "PriceListPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
