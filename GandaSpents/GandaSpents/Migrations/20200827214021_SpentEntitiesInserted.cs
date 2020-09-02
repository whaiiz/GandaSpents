using Microsoft.EntityFrameworkCore.Migrations;

namespace GandaSpents.Migrations
{
    public partial class SpentEntitiesInserted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SpentEntities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Continente" });

            migrationBuilder.InsertData(
                table: "SpentEntities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Dellman" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SpentEntities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SpentEntities",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
