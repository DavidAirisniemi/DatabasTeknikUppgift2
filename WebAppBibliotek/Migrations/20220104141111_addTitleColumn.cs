using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppBibliotek.Migrations
{
    public partial class addTitleColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "_title",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_title",
                table: "Books");
        }
    }
}
