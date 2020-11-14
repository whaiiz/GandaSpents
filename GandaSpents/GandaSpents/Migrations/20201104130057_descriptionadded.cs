using Microsoft.EntityFrameworkCore.Migrations;

namespace GandaSpents.Migrations
{
    public partial class descriptionadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Spents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Spents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Spents");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Spents",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
