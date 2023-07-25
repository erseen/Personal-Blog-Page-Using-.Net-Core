using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogErsen.Data.Migrations
{
    public partial class addPosShortDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostShortDescription",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostShortDescription",
                table: "Posts");
        }
    }
}
