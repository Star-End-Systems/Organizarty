using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizarty.Infra.Migrations
{
    /// <inheritdoc />
    public partial class partytype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PartyType",
                table: "PartyTemplates",
                type: "varchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartyType",
                table: "PartyTemplates");
        }
    }
}
