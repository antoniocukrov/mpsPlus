using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mpsPlus.API.Migrations
{
    /// <inheritdoc />
    public partial class password : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Employees_EmployeeId",
                table: "Receipts");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Receipts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Employees_EmployeeId",
                table: "Receipts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Employees_EmployeeId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employees");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeId",
                table: "Receipts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Employees_EmployeeId",
                table: "Receipts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
