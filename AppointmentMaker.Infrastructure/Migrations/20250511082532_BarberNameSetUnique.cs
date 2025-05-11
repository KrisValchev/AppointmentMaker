using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BarberNameSetUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2025, 5, 11, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2025, 5, 11, 12, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Barbers_BarberName",
                table: "Barbers",
                column: "BarberName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Barbers_BarberName",
                table: "Barbers");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2025, 5, 9, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2025, 5, 9, 12, 30, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
