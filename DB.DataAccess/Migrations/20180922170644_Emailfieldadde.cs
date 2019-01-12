using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.DataAccess.Migrations
{
    public partial class Emailfieldadde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Testimonial");

            migrationBuilder.DropColumn(
                name: "PId",
                table: "Testimonial");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Testimonial",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PId",
                table: "Testimonial",
                nullable: true);
        }
    }
}
