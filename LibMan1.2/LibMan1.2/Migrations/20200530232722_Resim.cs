using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibMan1._2.Migrations
{
    public partial class Resim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Table_BookInfo",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true),
                    AuthorName = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true),
                    PageNumber = table.Column<int>(nullable: true),
                    Image = table.Column<byte[]>(type: "image", nullable: true),
                    Publisher = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true),
                    Imagee = table.Column<string>(fixedLength: true, maxLength: 100, nullable: true),
                    BookSummary = table.Column<string>(fixedLength: true, maxLength: 1000, nullable: true),
                    Categories = table.Column<string>(fixedLength: true, maxLength: 50, nullable: true),
                    ReadingStatus = table.Column<string>(fixedLength: true, maxLength: 20, nullable: true),
                    UserName = table.Column<string>(fixedLength: true, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_BookInfo", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Table_UserInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(fixedLength: true, maxLength: 50, nullable: true),
                    Password = table.Column<string>(fixedLength: true, maxLength: 50, nullable: true),
                    Mail = table.Column<string>(fixedLength: true, maxLength: 50, nullable: true),
                    Name = table.Column<string>(fixedLength: true, maxLength: 50, nullable: true),
                    SurName = table.Column<string>(fixedLength: true, maxLength: 50, nullable: true),
                    Date = table.Column<string>(fixedLength: true, maxLength: 20, nullable: true),
                    Photo = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_UserInfo", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Table_AdminInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: true),
                    Password = table.Column<string>(fixedLength: true, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Table_AdminInfo_Table_UserInfo",
                        column: x => x.Id,
                        principalTable: "Table_UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Table_AdminInfo_Id",
                table: "Table_AdminInfo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Table_AdminInfo");

            migrationBuilder.DropTable(
                name: "Table_BookInfo");

            migrationBuilder.DropTable(
                name: "Table_UserInfo");
        }
    }
}
