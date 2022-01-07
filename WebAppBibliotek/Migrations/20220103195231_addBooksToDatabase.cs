using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppBibliotek.Migrations
{
    public partial class addBooksToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    _id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x._id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
