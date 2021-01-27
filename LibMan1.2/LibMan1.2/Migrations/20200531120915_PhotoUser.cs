using Microsoft.EntityFrameworkCore.Migrations;

namespace LibMan1._2.Migrations
{
    public partial class PhotoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Table_UserInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Table_UserInfo");
        }
    }
}
