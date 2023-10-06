using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore.Migrations
{
    public partial class author : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PublisherId",
                schema: "dbo",
                table: "Book",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthToBook",
                schema: "dbo",
                columns: table => new
                {
                    Author_Id = table.Column<long>(type: "bigint", nullable: false),
                    Book_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthToBook", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_AuthToBook_Author_Author_Id",
                        column: x => x.Author_Id,
                        principalSchema: "dbo",
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthToBook_Book_Book_Id",
                        column: x => x.Book_Id,
                        principalSchema: "dbo",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                schema: "dbo",
                table: "Book",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthToBook_Book_Id",
                schema: "dbo",
                table: "AuthToBook",
                column: "Book_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Publisher_PublisherId",
                schema: "dbo",
                table: "Book",
                column: "PublisherId",
                principalSchema: "dbo",
                principalTable: "Publisher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Publisher_PublisherId",
                schema: "dbo",
                table: "Book");

            migrationBuilder.DropTable(
                name: "AuthToBook",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Publisher",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Book_PublisherId",
                schema: "dbo",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                schema: "dbo",
                table: "Book");
        }
    }
}
