using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppointmentMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Barbers",
                columns: new[] { "Id", "BarberName" },
                values: new object[] { 1, "Denis" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "BarberId", "ClientNames", "Date", "Description", "PhoneNumber", "Time" },
                values: new object[,]
                {
                    { 1, 1, "Petar Ivanov", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "0871234567", new DateTime(2025, 5, 9, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Mihail Dimitrov", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "0870000000", new DateTime(2025, 5, 9, 12, 30, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Barbers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
