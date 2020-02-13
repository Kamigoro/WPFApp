using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseTestWPF.Migrations
{
    public partial class AddingEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "People",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "People");
        }
    }
}
