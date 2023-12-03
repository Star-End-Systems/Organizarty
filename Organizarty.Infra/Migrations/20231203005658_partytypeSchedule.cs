using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizarty.Infra.Migrations
{
    /// <inheritdoc />
    public partial class partytypeSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PartyType",
                table: "Schedules",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartyType",
                table: "Schedules");
        }
    }
}
