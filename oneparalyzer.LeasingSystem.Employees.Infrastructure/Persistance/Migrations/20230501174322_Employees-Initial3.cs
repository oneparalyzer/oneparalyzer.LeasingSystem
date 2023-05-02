using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oneparalyzer.LeasingSystem.Employees.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmployeesInitial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentIds_Offices_OfficeId",
                table: "DepartmentIds");

            migrationBuilder.RenameColumn(
                name: "OfficeId",
                table: "DepartmentIds",
                newName: "DepartmentId1");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentIds_OfficeId",
                table: "DepartmentIds",
                newName: "IX_DepartmentIds_DepartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentIds_Offices_DepartmentId1",
                table: "DepartmentIds",
                column: "DepartmentId1",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentIds_Offices_DepartmentId1",
                table: "DepartmentIds");

            migrationBuilder.RenameColumn(
                name: "DepartmentId1",
                table: "DepartmentIds",
                newName: "OfficeId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentIds_DepartmentId1",
                table: "DepartmentIds",
                newName: "IX_DepartmentIds_OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentIds_Offices_OfficeId",
                table: "DepartmentIds",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
