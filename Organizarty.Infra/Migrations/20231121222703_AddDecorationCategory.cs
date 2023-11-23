using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Organizarty.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddDecorationCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ServiceOrders",
                type: "decimal(2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,30)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ServiceInfos",
                type: "decimal(2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,30)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Schedules",
                type: "decimal(2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,30)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "FoodInfos",
                type: "decimal(2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,30)",
                oldPrecision: 2);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "DecorationTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "DecorationOrders",
                type: "decimal(2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,30)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "DecorationInfos",
                type: "decimal(2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,30)",
                oldPrecision: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "DecorationTypes");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ServiceOrders",
                type: "decimal(2,30)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "ServiceInfos",
                type: "decimal(2,30)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Schedules",
                type: "decimal(2,30)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "FoodInfos",
                type: "decimal(2,30)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "DecorationOrders",
                type: "decimal(2,30)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "DecorationInfos",
                type: "decimal(2,30)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2)",
                oldPrecision: 2);
        }
    }
}
