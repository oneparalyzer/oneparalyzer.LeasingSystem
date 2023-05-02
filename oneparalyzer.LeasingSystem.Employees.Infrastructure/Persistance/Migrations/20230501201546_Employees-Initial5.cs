using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmployeesInitial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Street_StreetId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_City_Region_RegionId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_Address_AddressId",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Street_City_CityId",
                table: "Street");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Street",
                table: "Street");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                table: "Region");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Street",
                newName: "Streets");

            migrationBuilder.RenameTable(
                name: "Region",
                newName: "Regions");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Street_Title",
                table: "Streets",
                newName: "IX_Streets_Title");

            migrationBuilder.RenameIndex(
                name: "IX_Street_CityId",
                table: "Streets",
                newName: "IX_Streets_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Region_Title",
                table: "Regions",
                newName: "IX_Regions_Title");

            migrationBuilder.RenameIndex(
                name: "IX_City_Title",
                table: "Cities",
                newName: "IX_Cities_Title");

            migrationBuilder.RenameIndex(
                name: "IX_City_RegionId",
                table: "Cities",
                newName: "IX_Cities_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_StreetId",
                table: "Addresses",
                newName: "IX_Addresses_StreetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Streets",
                table: "Streets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Streets_StreetId",
                table: "Addresses",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Regions_RegionId",
                table: "Cities",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Addresses_AddressId",
                table: "Offices",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Streets_Cities_CityId",
                table: "Streets",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Streets_StreetId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Regions_RegionId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Offices_Addresses_AddressId",
                table: "Offices");

            migrationBuilder.DropForeignKey(
                name: "FK_Streets_Cities_CityId",
                table: "Streets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Streets",
                table: "Streets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Streets",
                newName: "Street");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Region");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Streets_Title",
                table: "Street",
                newName: "IX_Street_Title");

            migrationBuilder.RenameIndex(
                name: "IX_Streets_CityId",
                table: "Street",
                newName: "IX_Street_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Regions_Title",
                table: "Region",
                newName: "IX_Region_Title");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_Title",
                table: "City",
                newName: "IX_City_Title");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_RegionId",
                table: "City",
                newName: "IX_City_RegionId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_StreetId",
                table: "Address",
                newName: "IX_Address_StreetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Street",
                table: "Street",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                table: "Region",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Street_StreetId",
                table: "Address",
                column: "StreetId",
                principalTable: "Street",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Region_RegionId",
                table: "City",
                column: "RegionId",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offices_Address_AddressId",
                table: "Offices",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Street_City_CityId",
                table: "Street",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
