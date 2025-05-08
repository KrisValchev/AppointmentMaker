using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppointmentMaker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Barber identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Barber's name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Appointment identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarberId = table.Column<int>(type: "int", nullable: false, comment: "Barber identifier"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Appointment date"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Appointment time"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Appointment description"),
                    ClientNames = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Client's names"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Client's phone number")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Barbers_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Barbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BarberId",
                table: "Appointments",
                column: "BarberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Barbers");
        }
    }
}
