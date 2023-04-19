using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oneparalyzer.LeasingSystem.Customers.Infrastructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StreetId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StreetId",
                table: "Addresses",
                column: "StreetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Streets_StreetId",
                table: "Addresses",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Streets_StreetId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StreetId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StreetId",
                table: "Addresses");
        }
    }
}
