using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HR.Leave.Management.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingLeaveTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveType",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DefaultDays", "LastUpdateDate", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "Matthew Oduamafu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, null, "Vacation", null },
                    { 2, "Matthew Oduamafu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, null, "Sick", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
