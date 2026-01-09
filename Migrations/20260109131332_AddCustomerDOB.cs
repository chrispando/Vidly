using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerDOB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2000,1,1));

                migrationBuilder.UpdateData(
    table: "Customers",
    keyColumn: "Id",
    keyValue: 1, 
    column: "DateOfBirth",
    value: new DateTime(1991, 3, 16)  // Changed from string to DateTime
);
migrationBuilder.UpdateData(
    table: "Customers",
    keyColumn: "Id",
    keyValue: 2, 
    column: "DateOfBirth",
    value: new DateTime(1997, 5, 7)  // Changed from string to DateTime
);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Customers");
        }
    }
}
