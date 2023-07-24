using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogErsen.Data.Migrations
{
    public partial class CategoryNameCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Posts");
        }
    }
}
