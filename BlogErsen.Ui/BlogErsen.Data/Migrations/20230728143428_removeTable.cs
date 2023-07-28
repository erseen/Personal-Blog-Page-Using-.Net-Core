using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogErsen.Data.Migrations
{
    public partial class removeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
        name: "Comment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
          name: "Comment",
       columns: table => new
       {
           CommentId = table.Column<int>(type: "int", nullable: false)
               .Annotation("SqlServer:Identity", "1, 1"),
           CommendText = table.Column<string>(type: "nvarchar(max)", nullable: true),
           Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
           IsApproved = table.Column<bool>(type: "bit", nullable: false),
           CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
       },
       constraints: table =>
       {
           table.PrimaryKey("PK_Comment", x => x.CommentId);
       });
        }
    }
}
