using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webOdev3.Migrations
{
    public partial class randevu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OnayDurumu",
                table: "Randevulars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnayDurumu",
                table: "Randevulars");
        }
    }
}
