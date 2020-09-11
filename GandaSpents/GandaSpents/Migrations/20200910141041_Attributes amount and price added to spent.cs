using Microsoft.EntityFrameworkCore.Migrations;

namespace GandaSpents.Migrations
{
    public partial class Attributesamountandpriceaddedtospent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Spents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Spents",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Spents");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Spents");
        }
    }
}
