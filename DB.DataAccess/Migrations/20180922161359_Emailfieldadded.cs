using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.DataAccess.Migrations
{
    public partial class Emailfieldadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Testimonial",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Testimonial");
        }
    }
}
