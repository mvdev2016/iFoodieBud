using Microsoft.EntityFrameworkCore.Migrations;

namespace iFoodieBud.Migrations
{
    public partial class updateDishModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Calories",
                table: "Dishes",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Dishes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Dishes");

            migrationBuilder.AlterColumn<float>(
                name: "Calories",
                table: "Dishes",
                type: "real",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);
        }
    }
}
