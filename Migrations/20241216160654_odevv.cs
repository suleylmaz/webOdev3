using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webOdev3.Migrations
{
    public partial class odevv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Kullanicilars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Kullanicilars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
