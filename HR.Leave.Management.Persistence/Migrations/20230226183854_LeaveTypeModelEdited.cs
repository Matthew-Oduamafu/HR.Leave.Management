using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Leave.Management.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LeaveTypeModelEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2023, 2, 26, 18, 38, 54, 367, DateTimeKind.Utc).AddTicks(2896));

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2023, 2, 26, 18, 38, 54, 367, DateTimeKind.Utc).AddTicks(2901));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "LeaveType",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
