using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDB_Storage.Data.Migrations
{
    public partial class bugfixed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "NUMERIC(2,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Movies",
                type: "NUMERIC(2,2)",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
