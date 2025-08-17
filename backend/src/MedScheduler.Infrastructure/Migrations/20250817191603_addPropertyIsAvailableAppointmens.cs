using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedScheduler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addPropertyIsAvailableAppointmens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Appointments",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Appointments");
        }
    }
}
